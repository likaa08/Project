namespace Model.Core;

public partial class Dog : Pet
{
    public string TrainingLevel { get; set; }
    public bool IsGuardDog { get; set; }

    public Dog(string nickname, int age, double weightKg, string breed, string trainingLevel, bool isGuardDog)
        : base(nickname, age, weightKg, breed)
    {
        TrainingLevel = trainingLevel;
        IsGuardDog = isGuardDog;
        Claustrophobia = false;
    }

    public override string AnimalKind => "Собака";

    public override string Title => "Пёс " + Nickname;

    public override string GetDescription() =>
        base.GetDescription() + $", дрессировка: {TrainingLevel}";
}
