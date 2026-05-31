using Model.Core;

namespace Model.Core.Interfaces;

public interface IChangeable
{
    bool AddPet(Pet pet);
    bool RemovePet(Pet pet);
}
