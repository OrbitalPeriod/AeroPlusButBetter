using System.Text.Json;

namespace AeroPlusButBetter.Utils;

public static class Config
{
    private static string Path = "Utils/config.json";

    private static Dictionary<string, string>? ReadJson()
    {
        using (StreamReader sr = new StreamReader(Path))
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(sr.ReadToEnd());
        }
    }
    private static string GetValueFromJson(string key)
    {
        Dictionary<string, string>? json = ReadJson();
        if (json == null) throw new Exception("JSON returned null");
        if (!json.ContainsKey(key)) throw new JsonException($"'{key}' not found in json");
        return json[key];
    }

    public static string GetSqlUsername()
    {
        return GetValueFromJson("SqlUsername");
    }

    public static string GetSqlPassword()
    {
        return GetValueFromJson("SqlPassword");
    }

    public static string GetSqlUrl()
    {
        return GetValueFromJson("SqlUrl");
    }

    public static int GetSqlPort()
    {
        return int.Parse(GetValueFromJson("SqlPort"));
    }
}