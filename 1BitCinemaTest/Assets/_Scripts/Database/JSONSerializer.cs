using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Xml;

public static class JsonSerializer
{
    public static T LoadFromJsonFile<T>(string fileName, bool fromResources = false) where T : class
    {
        if (fromResources)
        {
            var file = Resources.Load<TextAsset>(fileName);
            var jsonString = file.text;
            var obj = JsonConvert.DeserializeObject<T>(jsonString);
            return obj;
        }

        if (File.Exists(Application.persistentDataPath + $"/{fileName}.json"))
        {
            string fileContents = File.ReadAllText(Application.persistentDataPath + $"/{fileName}.json");
            var obj = JsonConvert.DeserializeObject<T>(fileContents);
            return obj;
        }

        return null;
    }

    public static void SaveObjectToFile(string fileName, object data)
    {
        try
        {
            var jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Application.persistentDataPath + $"/{fileName}.json", jsonString);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }
}