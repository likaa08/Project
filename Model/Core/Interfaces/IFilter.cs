using Model.Core;

namespace Model.Core.Interfaces;

public interface IFilter
{
    IEnumerable<Pet> Filter(Type? type);
}
