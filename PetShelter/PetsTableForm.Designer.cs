namespace PetShelter;

partial class PetsTableForm
{
    private DataGridView grid;
    private Label lblInfo;
    private Label lblShelter;
    private ComboBox cmbShelter;
    private Button btnAdd;
    private Button btnRemove;

    private void InitializeComponent()
    {
        Text = "Подборка питомцев";
        Size = new Size(780, 480);
        StartPosition = FormStartPosition.CenterScreen;

        grid = new DataGridView
        {
            Location = new Point(10, 10),
            Size = new Size(740, 300),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            ReadOnly = true,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        grid.Columns.Add("Kind", "Вид");
        grid.Columns.Add("Nickname", "Кличка");
        grid.Columns.Add("Age", "Возраст");
        grid.Columns.Add("Weight", "Вес, кг");
        grid.Columns.Add("Breed", "Порода");
        grid.Columns.Add("Claustro", "Клаустрофобия");
        grid.Columns.Add("Extra", "Доп. поле");
        grid.SelectionChanged += grid_SelectionChanged;

        lblShelter = new Label { Text = "Приют:", Location = new Point(10, 320), AutoSize = true };
        cmbShelter = new ComboBox
        {
            Location = new Point(60, 316),
            Width = 220,
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        btnAdd = new Button { Text = "Добавить", Location = new Point(300, 315), Size = new Size(90, 28) };
        btnRemove = new Button { Text = "Удалить", Location = new Point(400, 315), Size = new Size(90, 28) };
        btnAdd.Click += btnAdd_Click;
        btnRemove.Click += btnRemove_Click;

        lblInfo = new Label { Location = new Point(10, 355), Size = new Size(700, 30) };

        Controls.AddRange([grid, lblShelter, cmbShelter, btnAdd, btnRemove, lblInfo]);
    }
}
