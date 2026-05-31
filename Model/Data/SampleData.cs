using Model.Core;

namespace Model.Data;

public static class SampleData
{
    public static List<Shelter> Create()
    {
        var pets = CreatePets();

        var sunny = new Shelter("Солнечный", 10, true);
        var quiet = new Shelter("Тихий двор", 10, false);
        var forest = new Shelter("Лесная поляна", 10, true);

        // Солнечный — разные виды, часть с клаустрофобией (открытая территория)
        Place(sunny, pets, 0, 1, 2, 3, 4, 5, 21);

        // Тихий двор — закрытый приют: только БЕЗ клаустрофобии, несколько видов
        Place(quiet, pets, 10, 11, 12, 13, 14, 15, 16, 20, 22);

        // Лесная поляна
        Place(forest, pets, 6, 7, 8, 9, 17, 18, 19);

        return new List<Shelter> { sunny, quiet, forest };
    }

    private static void Place(Shelter shelter, List<Pet> all, params int[] indexes)
    {
        foreach (var i in indexes)
            shelter.AddPet(all[i]);
    }

    private static List<Pet> CreatePets()
    {
        var list = new PetList<Pet>();
        Pet[] pets =
        [
            // 0–5 Солнечный (клаустрофобия у кошки, собаки и кролика)
            new Cat("Мурка", 2, 4.1, "Дворовая", "рыжий", true, true),
            new Cat("Соня", 5, 3.8, "Сиамская", "кремовый", false, false),
            new Cat("Барсик", 1, 2.5, "Британская", "серый", true, false),
            new Dog("Рекс", 4, 18.0, "Овчарка", "высокая", true, true),
            new Dog("Шарик", 3, 12.0, "Дворняжка", "базовая", false, false),
            new Rabbit("Пушок", 1, 1.8, "Декоративный", 9.0, true, true),

            // 6–9 Лесная поляна
            new Dog("Лайка", 6, 20.0, "Хаски", "средняя", false, true),
            new Rabbit("Ушастик", 2, 2.1, "Вислоухий", 11.0, false, false),
            new Cat("Васька", 7, 5.0, "Мейн-кун", "полосатый", true, true),
            new Dog("Джек", 2, 8.5, "Терьер", "низкая", false, false),

            // 10–16 Тихий двор (все без клаустрофобии — иначе не поместятся)
            new Dog("Бим", 4, 14.0, "Спаниель", "базовая", false, false),
            new Cat("Злата", 3, 3.5, "Шотландская", "серый", true, false),
            new Rabbit("Нюша", 2, 1.9, "Ангорский", 10.0, true, false),
            new Dog("Гром", 5, 22.0, "Мастиф", "низкая", true, false),
            new Cat("Маркиз", 6, 4.8, "Абиссинская", "песочный", false, false),
            new Rabbit("Рыжик", 1, 1.6, "Карликовый", 8.5, false, false),
            new Dog("Чарли", 2, 9.0, "Бигль", "средняя", false, false),

            // 17–19 Лесная поляна
            new Rabbit("Снежок", 3, 2.0, "Белый гигант", 12.0, true, true),
            new Cat("Люся", 4, 3.2, "Персидская", "белый", false, true),
            new Dog("Бобик", 5, 15.0, "Лабрадор", "средняя", true, false),

            // 20 Тихий двор
            new Cat("Пикси", 2, 3.0, "Бенгальская", "пятнистый", true, false),

            // 21–22 попугаи
            new Parrot("Кеша", 3, 0.4, "Жако", "серый", true, true),
            new Parrot("Гоша", 5, 0.3, "Волнистый", "зелёный", false, false)
        ];
        foreach (var pet in pets)
            list.Add(pet);
        return list.GetAll().ToList();
    }
}
