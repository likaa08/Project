namespace Model.Data;

public abstract class SerializerBase<T>
{
    public abstract void Save(string path, T data);
    public abstract T Load(string path);
}
