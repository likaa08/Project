# PetShelter

## Запуск

```bash
dotnet run --project PetShelter
```

Данные: `%LocalAppData%\PetShelter\shelters.json`  
Отчёты: `%LocalAppData%\PetShelter\Reports\`

## Структура

- **Model/Core** — Pet, Cat, Dog, Rabbit, Parrot, Shelter, интерфейсы
- **Model/Data** — JSON/XML, файлы
- **PetShelter** — окна (меню, таблица)
- **PetHelper** — общая логика видов животных для UI

## ООП (для защиты)

| Требование | Где |
|------------|-----|
| Интерфейсы | ICountable, IFilter, IChangeable |
| Абстрактные классы | Pet, SerializerBase&lt;T&gt; |
| partial | Pet, Shelter, наследники |
| Перегрузки | Count(), Filter(Type), Filter(Type, bool) |
| Переопределения | GetDescription, AnimalKind, Title |
| Оператор | Pet ==, != |
| Делегат | Predicate в Shelter.Filter |
| Generics | PetList&lt;T&gt;, SerializerBase&lt;T&gt; |
