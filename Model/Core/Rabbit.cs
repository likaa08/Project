namespace Model.Core;

public partial class Rabbit : Pet
{
    public double EarLengthCm { get; set; }
    public bool CanJumpHigh { get; set; }

    public Rabbit(string nickname, int age, double weightKg, string breed, double earLengthCm, bool canJumpHigh)
        : base(nickname, age, weightKg, breed)
    {
        EarLengthCm = earLengthCm;
        CanJumpHigh = canJumpHigh;
        Claustrophobia = false;
    }

    public override string AnimalKind => "Кролик";

    public override string Title => "Кролик " + Nickname;

    public override string GetDescription() =>
        base.GetDescription() + $", уши: {EarLengthCm} см";
}
