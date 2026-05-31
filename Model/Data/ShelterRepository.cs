using Model.Core;

namespace Model.Data;

public class ShelterRepository
{
    private readonly string _folder;
    private readonly JsonSerializerService<List<ShelterDto>> _json = new();

    public ShelterRepository(string folder) => _folder = folder;

    private string DataFile => Path.Combine(_folder, "shelters.json");

    public List<Shelter> Load()
    {
        try
        {
            if (!File.Exists(DataFile))
                throw new FileNotFoundException();
            var dtos = _json.Load(DataFile);
            return dtos.Select(ToShelter).ToList();
        }
        catch
        {
            var sample = SampleData.Create();
            Save(sample);
            return sample;
        }
    }

    public void Save(List<Shelter> shelters)
    {
        Directory.CreateDirectory(_folder);
        _json.Save(DataFile, shelters.Select(ToDto).ToList());
    }

    private static Shelter ToShelter(ShelterDto dto)
    {
        var shelter = new Shelter(dto.Name, dto.Capacity, dto.HasOpenArea);
        foreach (var petDto in dto.Pets)
            shelter.AddPet(PetFactory.Create(petDto));
        return shelter;
    }

    private static ShelterDto ToDto(Shelter shelter) => new()
    {
        Name = shelter.Name,
        Capacity = shelter.Capacity,
        HasOpenArea = shelter.HasOpenArea,
        Pets = shelter.Pets.Select(PetFactory.ToDto).ToList()
    };
}
