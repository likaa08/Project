namespace Model.Core;

public abstract partial class Pet
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public double WeightKg { get; set; }
    public string Breed { get; set; }

    protected Pet(string nickname, int age, double weightKg, string breed)
    {
        Nickname = nickname;
        Age = age;
        WeightKg = weightKg;
        Breed = breed;
    }

    public abstract string AnimalKind { get; }

    public virtual string Title => Nickname;

    public virtual string GetDescription() =>
        $"{Nickname} ({AnimalKind}), {Age} лет, {WeightKg} кг";

    public override string ToString() => GetDescription();

    public override bool Equals(object? obj) =>
        obj is Pet other && Nickname == other.Nickname && AnimalKind == other.AnimalKind;

    public override int GetHashCode() => HashCode.Combine(Nickname, AnimalKind);

    public static bool operator ==(Pet? left, Pet? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Pet? left, Pet? right) => !(left == right);
}
