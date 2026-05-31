namespace Model.Core;

public class PetList<T> where T : Pet
{
    private readonly List<T> _items = new();

    public void Add(T pet) => _items.Add(pet);

    public IEnumerable<T> GetAll() => _items;

    public int Count() => _items.Count;
}
