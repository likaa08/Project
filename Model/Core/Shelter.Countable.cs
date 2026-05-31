using Model.Core.Interfaces;

namespace Model.Core;

public partial class Shelter : ICountable
{
    public int Count() => _pets.Count;

    public int Count(Type type) =>
        _pets.Count(p => p.GetType() == type);

    public int Percentage(Type type)
    {
        if (_pets.Count == 0) return 0;
        return Count(type) * 100 / _pets.Count;
    }
}
