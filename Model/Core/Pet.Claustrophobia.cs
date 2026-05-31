namespace Model.Core;

public abstract partial class Pet
{
    public bool Claustrophobia { get; protected set; }

    protected Pet(string nickname, int age, double weightKg, string breed, bool claustrophobia)
        : this(nickname, age, weightKg, breed)
    {
        Claustrophobia = claustrophobia;
    }
}
