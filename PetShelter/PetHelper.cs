using Model.Core;

namespace PetShelter;

public static class PetHelper
{
    public static readonly string[] Kinds = ["Cat", "Dog", "Rabbit", "Parrot"];

    public static Type? ToType(string? kindName) => kindName switch
    {
        "Cat" => typeof(Cat),
        "Dog" => typeof(Dog),
        "Rabbit" => typeof(Rabbit),
        "Parrot" => typeof(Parrot),
        _ => null
    };

    public static string GetExtraInfo(Pet pet) => pet switch
    {
        Cat c => c.FurColor,
        Dog d => d.TrainingLevel,
        Rabbit r => $"{r.EarLengthCm} см",
        Parrot p => p.FeatherColor,
        _ => ""
    };

    public static Pet Create(string kind, string nick, int age, double weight, string breed,
        string extra1, bool extra2, bool claustrophobia) => kind switch
    {
        "Cat" => new Cat(nick, age, weight, breed, extra1, extra2, claustrophobia),
        "Dog" => new Dog(nick, age, weight, breed, extra1, extra2, claustrophobia),
        "Rabbit" => new Rabbit(nick, age, weight, breed,
            double.TryParse(extra1, out var ears) ? ears : 10, extra2, claustrophobia),
        "Parrot" => new Parrot(nick, age, weight, breed, extra1, extra2, claustrophobia),
        _ => throw new ArgumentException("Неизвестный вид: " + kind)
    };
}
