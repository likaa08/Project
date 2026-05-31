namespace Model.Data;

public class ShelterDto
{
    public string Name { get; set; } = "";
    public int Capacity { get; set; }
    public bool HasOpenArea { get; set; }
    public List<PetDto> Pets { get; set; } = new();
}

public class PetDto
{
    public string Kind { get; set; } = "";
    public string Nickname { get; set; } = "";
    public int Age { get; set; }
    public double WeightKg { get; set; }
    public string Breed { get; set; } = "";
    public bool Claustrophobia { get; set; }
    public string Extra1 { get; set; } = "";
    public string Extra2 { get; set; } = "";
}
