namespace PetShelter;

partial class MainForm
{
    private ComboBox cmbShelter;
    private ComboBox cmbType;
    private ComboBox cmbFormat;
    private CheckBox chkOpenAreaOnly;
    private CheckBox chkClaustrophobic;
    private Button btnShow;
    private Label lblShelter;
    private Label lblType;
    private Label lblFormat;

    private void InitializeComponent()
    {
        Text = "Приют для животных — главное меню";
        Width = 480;
        Height = 320;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        lblShelter = new Label { Text = "Приют:", Left = 20, Top = 20, Width = 120 };
        cmbShelter = new ComboBox { Left = 150, Top = 17, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };

        lblType = new Label { Text = "Вид животного:", Left = 20, Top = 60, Width = 120 };
        cmbType = new ComboBox { Left = 150, Top = 57, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };

        chkOpenAreaOnly = new CheckBox
        {
            Text = "Только приюты с открытой территорией",
            Left = 150,
            Top = 95,
            Width = 280
        };

        chkClaustrophobic = new CheckBox
        {
            Text = "Только с клаустрофобией",
            Left = 150,
            Top = 125,
            Width = 280
        };

        lblFormat = new Label { Text = "Формат отчёта:", Left = 20, Top = 165, Width = 120 };
        cmbFormat = new ComboBox { Left = 150, Top = 162, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbFormat.SelectedIndexChanged += cmbFormat_SelectedIndexChanged;

        btnShow = new Button
        {
            Text = "Показать питомцев",
            Left = 150,
            Top = 210,
            Width = 200,
            Height = 35
        };
        btnShow.Click += btnShow_Click;

        Controls.AddRange(new Control[]
        {
            lblShelter, cmbShelter, lblType, cmbType,
            chkOpenAreaOnly, chkClaustrophobic,
            lblFormat, cmbFormat, btnShow
        });
    }
}
