using System.IO;
using UnityEngine;

public class TransformSaver : MonoBehaviour
{
    private string jsonPath;

    private void Awake()
    {
        jsonPath = Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    // Save entire GameData (positions + score)
    public void Save(GameData data)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(jsonPath, json);
            Debug.Log("Saved JSON: " + jsonPath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save json: " + e);
        }
    }

    // Load entire GameData
    public GameData Load()
    {
        GameData data = new GameData();

        try
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                GameData loaded = JsonUtility.FromJson<GameData>(json);
                if (loaded != null)
                    data = loaded;
            }
            else
            {
                Debug.Log("No save file found, starting fresh.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load json: " + e);
        }

        return data;
    }
}