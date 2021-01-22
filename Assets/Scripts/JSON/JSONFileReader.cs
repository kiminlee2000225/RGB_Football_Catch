using UnityEngine;

public class JSONFileReader
{
    // Return the json data as a string with the given file path as a string. 
    public static string LoadJsonAsResource(string path)
    {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonFile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonFile.text;
    }
}
