using System.Xml.Serialization;

namespace Model.Data;

public class XmlSerializerService<T> : SerializerBase<T>
{
    public override void Save(string path, T data)
    {
        using var writer = new StreamWriter(path);
        new XmlSerializer(typeof(T)).Serialize(writer, data);
    }

    public override T Load(string path)
    {
        using var reader = new StreamReader(path);
        return (T)new XmlSerializer(typeof(T)).Deserialize(reader)!;
    }
}
