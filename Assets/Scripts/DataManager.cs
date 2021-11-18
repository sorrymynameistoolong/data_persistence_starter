using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayer;
    public int currentScore;
    public string highScorePlayer;
    public int highScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayer;
        public int highScore;
    }

    public void Save()
    {
        if(currentScore > highScore)
        {
            SaveData data = new SaveData();
            data.highScorePlayer = currentPlayer;
            data.highScore = currentScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
        }
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayer = data.highScorePlayer;
            highScore = data.highScore;
        }
    }


}
