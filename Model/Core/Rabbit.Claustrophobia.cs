namespace Model.Core;

public partial class Rabbit
{
    public Rabbit(string nickname, int age, double weightKg, string breed, double earLengthCm, bool canJumpHigh, bool claustrophobia)
        : base(nickname, age, weightKg, breed, claustrophobia)
    {
        EarLengthCm = earLengthCm;
        CanJumpHigh = canJumpHigh;
    }
}
