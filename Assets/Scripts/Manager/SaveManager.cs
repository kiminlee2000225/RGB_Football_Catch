using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public string folderName = "save";
    public string fileName = "save.json";

    public static string directoryPath;
    public static string fullPath;

    // Sets the directory path and the full path for the save folder and file. 
    private void Awake()
    {
        directoryPath = Path.Combine(Application.persistentDataPath, folderName);
        fullPath = Path.Combine(directoryPath, fileName);
    }

    /* 
     * Saves the game. Check if the save directory already exists. If not, create
     * a new directory for the save file. Create a Save object (that holds the highscore)
     * and convert it to a json string. Save the json string to the identified filepath. 
    */
    public static void SaveGame()
    {
        if (!Directory.Exists(directoryPath)) {
            Directory.CreateDirectory(directoryPath);
        }
        Save save = new Save();
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(fullPath, json);
    }

    /* 
     * Loads the game. Checks if save file exists. If not, there is no data to load, so the
     * game starts as if it is the first time playing. Otherwise, load the saved json file to 
     * a Save object, then set the highscore in the GameStateManager depending on what highscore
     * has been loaded into the Save object. 
    */
    public static void LoadGame()
    {
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            Save save = JsonUtility.FromJson<Save>(json);
            GameStateManager.highscore = save.highscore;
        } else
        {
            Debug.Log("There are no existing save files!");
        }
    }
}
