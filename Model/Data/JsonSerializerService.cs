using System.Text.Json;

namespace Model.Data;

public class JsonSerializerService<T> : SerializerBase<T>
{
    public override void Save(string path, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public override T Load(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}
