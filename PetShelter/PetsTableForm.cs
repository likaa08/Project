using Model.Core;
using Model.Core.Interfaces;
using Model.Data;

namespace PetShelter;

public partial class PetsTableForm : Form
{
    private readonly List<Pet> _pets;
    private readonly string _savedPath;

    public PetsTableForm(List<Pet> pets, string? defaultShelterName, string savedPath)
    {
        _pets = pets;
        _savedPath = savedPath;
        InitializeComponent();

        foreach (var s in AppState.Shelters)
            cmbShelter.Items.Add(s.Name);

        if (!string.IsNullOrEmpty(defaultShelterName))
        {
            int i = cmbShelter.Items.IndexOf(defaultShelterName);
            if (i >= 0) cmbShelter.SelectedIndex = i;
        }
        else if (cmbShelter.Items.Count > 0)
            cmbShelter.SelectedIndex = 0;

        RefreshTable();
    }

    private Shelter? CurrentShelter()
    {
        string? name = cmbShelter.SelectedItem as string;
        return name is null ? null : AppState.Shelters.FirstOrDefault(s => s.Name == name);
    }

    private void RefreshTable()
    {
        grid.Rows.Clear();
        foreach (var pet in _pets)
        {
            grid.Rows.Add(pet.AnimalKind, pet.Nickname, pet.Age, pet.WeightKg, pet.Breed,
                pet.Claustrophobia ? "да" : "нет", PetHelper.GetExtraInfo(pet));
        }
        string info = $"{Path.GetFileName(_savedPath)} | В таблице: {_pets.Count}";
        if (CurrentShelter() is Shelter s)
        {
            ICountable counter = s;
            info += $" | В приюте: {counter.Count()}";
        }
        lblInfo.Text = info;
        btnRemove.Enabled = grid.SelectedRows.Count > 0;
    }

    private void grid_SelectionChanged(object sender, EventArgs e) =>
        btnRemove.Enabled = grid.SelectedRows.Count > 0;

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        var shelter = CurrentShelter();
        if (shelter is null) return;

        var pet = AddPetForm.Ask(this);
        if (pet is null) return;

        IChangeable editable = shelter;
        if (!editable.AddPet(pet))
        {
            shelter.TryAddPet(pet, out string? error);
            MessageBox.Show(error ?? "Нельзя добавить", "Добавление");
            return;
        }

        if (!_pets.Contains(pet))
            _pets.Add(pet);
        AppState.Save();

        try
        {
            AppState.Reports.SavePetToReportsIfNew(pet, AppState.CurrentFormat);
            var alt = AppState.CurrentFormat == ReportFormat.Json ? ReportFormat.Xml : ReportFormat.Json;
            AppState.Reports.SavePetToReportsIfNew(pet, alt);
        }
        catch { /* отчёт не блокирует добавление */ }

        RefreshTable();
    }

    private void btnRemove_Click(object? sender, EventArgs e)
    {
        var shelter = CurrentShelter();
        if (shelter is null || grid.SelectedRows.Count == 0) return;

        int i = grid.SelectedRows[0].Index;
        if (i < 0 || i >= _pets.Count) return;

        IChangeable editable = shelter;
        editable.RemovePet(_pets[i]);
        _pets.RemoveAt(i);
        AppState.Save();
        RefreshTable();
    }
}
