using Model.Core;

namespace Model.Data;

public static class PetFactory
{
    public static Pet Create(PetDto dto) => dto.Kind switch
    {
        "Cat" => new Cat(dto.Nickname, dto.Age, dto.WeightKg, dto.Breed, dto.Extra1, dto.Extra2 == "1", dto.Claustrophobia),
        "Dog" => new Dog(dto.Nickname, dto.Age, dto.WeightKg, dto.Breed, dto.Extra1, dto.Extra2 == "1", dto.Claustrophobia),
        "Rabbit" => new Rabbit(dto.Nickname, dto.Age, dto.WeightKg, dto.Breed, double.Parse(dto.Extra1), dto.Extra2 == "1", dto.Claustrophobia),
        "Parrot" => new Parrot(dto.Nickname, dto.Age, dto.WeightKg, dto.Breed, dto.Extra1, dto.Extra2 == "1", dto.Claustrophobia),
        _ => throw new ArgumentException("Неизвестный вид: " + dto.Kind)
    };

    public static PetDto ToDto(Pet pet)
    {
        var dto = new PetDto
        {
            Nickname = pet.Nickname,
            Age = pet.Age,
            WeightKg = pet.WeightKg,
            Breed = pet.Breed,
            Claustrophobia = pet.Claustrophobia
        };

        switch (pet)
        {
            case Cat c:
                dto.Kind = "Cat"; dto.Extra1 = c.FurColor; dto.Extra2 = c.LikesBoxes ? "1" : "0"; break;
            case Dog d:
                dto.Kind = "Dog"; dto.Extra1 = d.TrainingLevel; dto.Extra2 = d.IsGuardDog ? "1" : "0"; break;
            case Rabbit r:
                dto.Kind = "Rabbit"; dto.Extra1 = r.EarLengthCm.ToString(); dto.Extra2 = r.CanJumpHigh ? "1" : "0"; break;
            case Parrot p:
                dto.Kind = "Parrot"; dto.Extra1 = p.FeatherColor; dto.Extra2 = p.CanTalk ? "1" : "0"; break;
        }
        return dto;
    }
}
