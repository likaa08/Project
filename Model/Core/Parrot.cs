namespace Model.Core;

public partial class Parrot : Pet
{
    public string FeatherColor { get; set; }
    public bool CanTalk { get; set; }

    public Parrot(string nickname, int age, double weightKg, string breed, string featherColor, bool canTalk)
        : base(nickname, age, weightKg, breed)
    {
        FeatherColor = featherColor;
        CanTalk = canTalk;
        Claustrophobia = false;
    }

    public override string AnimalKind => "Попугай";

    public override string Title => "Попугай " + Nickname;

    public override string GetDescription() =>
        base.GetDescription() + $", оперение: {FeatherColor}, говорит: {(CanTalk ? "да" : "нет")}";
}
