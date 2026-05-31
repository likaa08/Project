namespace Model.Core;

public partial class Shelter
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public bool HasOpenArea { get; set; }

    private readonly List<Pet> _pets = new();

    public Shelter(string name, int capacity, bool hasOpenArea)
    {
        Name = name;
        Capacity = capacity;
        HasOpenArea = hasOpenArea;
    }

    public IReadOnlyList<Pet> Pets => _pets;

    public bool CanPlacePet(Pet pet)
    {
        if (_pets.Count >= Capacity) return false;
        if (pet.Claustrophobia && !HasOpenArea) return false;
        return true;
    }

    internal List<Pet> PetsInternal => _pets;
}
