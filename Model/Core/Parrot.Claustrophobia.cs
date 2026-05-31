namespace Model.Core;

public partial class Parrot
{
    public Parrot(string nickname, int age, double weightKg, string breed, string featherColor, bool canTalk, bool claustrophobia)
        : this(nickname, age, weightKg, breed, featherColor, canTalk)
    {
        Claustrophobia = claustrophobia;
    }
}
