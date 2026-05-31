using Model.Core.Interfaces;

namespace Model.Core;

public partial class Shelter : IFilter
{
    public IEnumerable<Pet> Filter(Type? type)
    {
        if (type is null) return _pets.ToList();
        return _pets.Where(p => p.GetType() == type);
    }

    public IEnumerable<Pet> Filter(Type? type, bool onlyClaustrophobic)
    {
        Predicate<Pet> rule = p => p.Claustrophobia == onlyClaustrophobic;
        return Filter(type).Where(p => rule(p));
    }
}
