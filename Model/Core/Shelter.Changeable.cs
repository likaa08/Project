using Model.Core.Interfaces;

namespace Model.Core;

public partial class Shelter : IChangeable
{
    public bool AddPet(Pet pet) => TryAddPet(pet, out _);

    public bool TryAddPet(Pet pet, out string? error)
    {
        if (_pets.Count >= Capacity)
        {
            error = "В приюте нет свободных мест.";
            return false;
        }
        if (pet.Claustrophobia && !HasOpenArea)
        {
            error = "С клаустрофобией нельзя в закрытый приют.";
            return false;
        }
        if (_pets.Any(p => p.Nickname == pet.Nickname && p.GetType() == pet.GetType()))
        {
            error = "Такой питомец уже есть в приюте.";
            return false;
        }
        _pets.Add(pet);
        error = null;
        return true;
    }

    public bool RemovePet(Pet pet) => _pets.Remove(pet);
}
