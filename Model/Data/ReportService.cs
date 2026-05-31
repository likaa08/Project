using Model.Core;

namespace Model.Data;

public enum ReportFormat { Json, Xml }

public class ReportService
{
    private readonly string _folder;
    private int _counter;
    private readonly JsonSerializerService<SelectionReport> _json = new();
    private readonly XmlSerializerService<SelectionReport> _xml = new();

    public ReportService(string folder)
    {
        _folder = folder;
        Directory.CreateDirectory(_folder);
        _counter = Directory.GetFiles(_folder, "Подборка_*").Length + 1;
    }

    public string SaveSelection(string shelterName, IEnumerable<Pet> pets, ReportFormat format)
    {
        var report = MakeReport(shelterName, pets);
        string ext = format == ReportFormat.Json ? "json" : "xml";
        string path = Path.Combine(_folder, $"Подборка_№{_counter}_от_{DateTime.Now:dd.MM.yyyy}.{ext}");
        Save(path, report, format);
        _counter++;
        return path;
    }

    public void SavePetToReportsIfNew(Pet pet, ReportFormat format)
    {
        string ext = format == ReportFormat.Json ? "json" : "xml";
        foreach (var file in Directory.GetFiles(_folder, $"Подборка_*.{ext}"))
        {
            var report = Load(file, format);
            if (report.Pets.Any(r => r.Nickname == pet.Nickname && r.Kind == pet.AnimalKind))
                return;
        }

        var newReport = MakeReport("Новый питомец", [pet]);
        string path = Path.Combine(_folder, $"Питомец_{pet.Nickname}_{DateTime.Now:ddMMyyyy}.{ext}");
        Save(path, newReport, format);
    }

    public void ConvertAllReports(ReportFormat from, ReportFormat to)
    {
        if (from == to) return;
        string ext = from == ReportFormat.Json ? "json" : "xml";
        foreach (var file in Directory.GetFiles(_folder, $"Подборка_*.{ext}"))
        {
            var report = Load(file, from);
            Save(Path.ChangeExtension(file, to == ReportFormat.Json ? "json" : "xml"), report, to);
        }
    }

    private static SelectionReport MakeReport(string shelterName, IEnumerable<Pet> pets) => new()
    {
        ShelterName = shelterName,
        CreatedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
        Pets = pets.Select(p => new PetRowDto
        {
            Kind = p.AnimalKind,
            Nickname = p.Nickname,
            Age = p.Age,
            WeightKg = p.WeightKg,
            Breed = p.Breed,
            Claustrophobia = p.Claustrophobia,
            Extra = p.GetDescription()
        }).ToList()
    };

    private void Save(string path, SelectionReport report, ReportFormat format)
    {
        if (format == ReportFormat.Json) _json.Save(path, report);
        else _xml.Save(path, report);
    }

    private SelectionReport Load(string path, ReportFormat format) =>
        format == ReportFormat.Json ? _json.Load(path) : _xml.Load(path);
}
