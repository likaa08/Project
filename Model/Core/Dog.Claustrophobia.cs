namespace Model.Core;

public partial class Dog
{
    public Dog(string nickname, int age, double weightKg, string breed, string trainingLevel, bool isGuardDog, bool claustrophobia)
        : this(nickname, age, weightKg, breed, trainingLevel, isGuardDog)
    {
        Claustrophobia = claustrophobia;
    }
}
