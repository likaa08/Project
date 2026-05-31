namespace Model.Data;

public class SelectionReport
{
    public string ShelterName { get; set; } = "";
    public string CreatedAt { get; set; } = "";
    public List<PetRowDto> Pets { get; set; } = new();
}

public class PetRowDto
{
    public string Kind { get; set; } = "";
    public string Nickname { get; set; } = "";
    public int Age { get; set; }
    public double WeightKg { get; set; }
    public string Breed { get; set; } = "";
    public bool Claustrophobia { get; set; }
    public string Extra { get; set; } = "";
}
