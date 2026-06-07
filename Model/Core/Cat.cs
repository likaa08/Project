namespace Model.Core;

public partial class Cat : Pet
{
    public string FurColor { get; set; }
    public bool LikesBoxes { get; set; }

    public Cat(string nickname, int age, double weightKg, string breed, string furColor, bool likesBoxes)
        : base(nickname, age, weightKg, breed)
    {
        FurColor = furColor;
        LikesBoxes = likesBoxes;
        Claustrophobia = true;
    }

    public override string AnimalKind => "Кошка";

    public override string Title => "Кот " + Nickname;

    public override string GetDescription() =>
        base.GetDescription() + $", окрас: {FurColor}";
}
