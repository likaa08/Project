using Model.Core;
using Model.Core.Interfaces;
using Model.Data;

namespace PetShelter;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        AppState.Load();
        FillCombos();
    }

    private void FillCombos()
    {
        cmbShelter.Items.Clear();
        cmbShelter.Items.Add("(все приюты)");
        foreach (var s in AppState.Shelters)
            cmbShelter.Items.Add(s.Name);

        cmbType.Items.Clear();
        cmbType.Items.Add("(все виды)");
        foreach (var kind in PetHelper.Kinds)
            cmbType.Items.Add(kind);

        cmbFormat.Items.Clear();
        cmbFormat.Items.Add("JSON");
        cmbFormat.Items.Add("XML");
        cmbFormat.SelectedIndex = 0;
        cmbShelter.SelectedIndex = 0;
        cmbType.SelectedIndex = 0;
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            var shelters = GetShelters();
            var petType = cmbType.SelectedIndex > 0 ? PetHelper.ToType(cmbType.Text) : null;
            var pets = GetFilteredPets(shelters, petType, chkClaustrophobic.Checked);

            string? editShelter = cmbShelter.SelectedIndex > 0 ? cmbShelter.Text
                : shelters.Count == 1 ? shelters[0].Name : null;

            if (pets.Count == 0 && editShelter is null)
            {
                MessageBox.Show("Питомцев нет. Выберите один приют, чтобы добавить нового.");
                return;
            }

            string title = cmbShelter.SelectedIndex <= 0 ? "Все приюты" : cmbShelter.Text;
            Func<string, string> save = name =>
                AppState.Reports.SaveSelection(name, pets, AppState.CurrentFormat);
            string path = save(title);
            new PetsTableForm(pets, editShelter, path).Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка");
        }
    }

    private List<Shelter> GetShelters()
    {
        var list = AppState.Shelters.AsEnumerable();
        if (chkOpenAreaOnly.Checked)
            list = list.Where(s => s.HasOpenArea);
        if (cmbShelter.SelectedIndex > 0)
            list = list.Where(s => s.Name == cmbShelter.Text);
        return list.ToList();
    }

    private static List<Pet> GetFilteredPets(List<Shelter> shelters, Type? petType, bool onlyClaustrophobic)
    {
        var result = new PetList<Pet>();

        foreach (Shelter shelter in shelters)
        {
            IFilter filter = shelter;
            ICountable counter = shelter;

            IEnumerable<Pet> found = onlyClaustrophobic
                ? shelter.Filter(petType, true)
                : filter.Filter(petType);

            foreach (Pet pet in found)
            {
                Pet asPet = pet;
                if (asPet is Cat) { }
                else if (asPet is Dog) { }
                else if (asPet is Rabbit) { }
                else if (asPet is Parrot) { }

                result.Add(asPet);
            }

            counter.Count();
            if (petType is not null)
                counter.Percentage(petType);
        }

        return result.GetAll().ToList();
    }

    private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        var newFormat = cmbFormat.Text == "XML" ? ReportFormat.Xml : ReportFormat.Json;
        if (AppState.CurrentFormat == newFormat) return;
        AppState.Reports.ConvertAllReports(AppState.CurrentFormat, newFormat);
        AppState.CurrentFormat = newFormat;
    }
}
