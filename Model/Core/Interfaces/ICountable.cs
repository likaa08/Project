namespace Model.Core.Interfaces;

public interface ICountable
{
    int Count();
    int Count(Type type);
    int Percentage(Type type);
}
