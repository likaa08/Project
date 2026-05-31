namespace Model.Core;

public partial class Cat
{
    public Cat(string nickname, int age, double weightKg, string breed, string furColor, bool likesBoxes, bool claustrophobia)
        : this(nickname, age, weightKg, breed, furColor, likesBoxes)
    {
        Claustrophobia = claustrophobia;
    }
}
