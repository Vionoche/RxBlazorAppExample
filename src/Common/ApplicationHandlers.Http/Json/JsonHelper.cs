using System.Text.Json;

namespace ApplicationHandlers.Http.Json;

public static class JsonHelper
{
    public static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value);
    }
    
    public static T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, DefaultOptions);
    }
    
    private static readonly JsonSerializerOptions? DefaultOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}