using Model.Core;
using Model.Data;

namespace PetShelter;

public static class AppState
{
    public static string DataFolder { get; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PetShelter");

    public static string ReportsFolder => Path.Combine(DataFolder, "Reports");

    public static List<Shelter> Shelters { get; private set; } = new();

    public static ShelterRepository Repository { get; } = new(DataFolder);

    public static ReportService Reports { get; } = new(ReportsFolder);

    public static ReportFormat CurrentFormat { get; set; } = ReportFormat.Json;

    public static void Load() => Shelters = Repository.Load();

    public static void Save() => Repository.Save(Shelters);
}
