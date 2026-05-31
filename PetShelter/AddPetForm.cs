using Model.Core;

namespace PetShelter;

public class AddPetForm : Form
{
    public Pet? CreatedPet { get; private set; }

    private readonly ComboBox _kind = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly TextBox _nickname = new();
    private readonly NumericUpDown _age = new() { Minimum = 0, Maximum = 30, Value = 1 };
    private readonly NumericUpDown _weight = new() { Minimum = 0.1m, Maximum = 100, DecimalPlaces = 1, Value = 3 };
    private readonly TextBox _breed = new();
    private readonly TextBox _extra1 = new();
    private readonly CheckBox _extra2 = new();
    private readonly CheckBox _claustro = new();

    public AddPetForm()
    {
        Text = "Новый питомец";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(310, 330);

        _kind.Items.AddRange(PetHelper.Kinds);
        _kind.SelectedIndex = 0;

        int y = 12;
        AddRow("Вид:", _kind, ref y);
        AddRow("Кличка:", _nickname, ref y);
        AddRow("Возраст:", _age, ref y);
        AddRow("Вес:", _weight, ref y);
        AddRow("Порода:", _breed, ref y);
        AddRow("Доп. 1:", _extra1, ref y);
        AddRow("Доп. 2:", _extra2, ref y);
        AddRow("Клаустрофобия:", _claustro, ref y);

        var ok = new Button { Text = "OK", Location = new Point(120, y), Size = new Size(80, 28) };
        var cancel = new Button { Text = "Отмена", Location = new Point(210, y), Size = new Size(80, 28) };
        ok.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_nickname.Text))
            {
                MessageBox.Show("Введите кличку.");
                return;
            }
            CreatedPet = PetHelper.Create(_kind.Text, _nickname.Text.Trim(), (int)_age.Value,
                (double)_weight.Value, _breed.Text, _extra1.Text, _extra2.Checked, _claustro.Checked);
            DialogResult = DialogResult.OK;
        };
        cancel.Click += (_, _) => DialogResult = DialogResult.Cancel;
        Controls.AddRange([ok, cancel]);
        AcceptButton = ok;
        CancelButton = cancel;
    }

    public static Pet? Ask(IWin32Window owner)
    {
        using var f = new AddPetForm();
        return f.ShowDialog(owner) == DialogResult.OK ? f.CreatedPet : null;
    }

    private void AddRow(string text, Control c, ref int y)
    {
        Controls.Add(new Label { Text = text, Location = new Point(12, y + 3), AutoSize = true });
        c.Location = new Point(120, y);
        c.Width = 170;
        Controls.Add(c);
        y += 32;
    }
}
