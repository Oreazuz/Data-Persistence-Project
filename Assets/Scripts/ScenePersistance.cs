using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenePersistance : MonoBehaviour
{

    public static ScenePersistance Instance;
    public string TopScorePlayerName;
    public int TopScore;
    public string CurrentPlayerName;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance !=null)
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
        public int TopScore;
        public string TopScorePlayerName;
    }  


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.TopScore = TopScore;
        data.TopScorePlayerName = TopScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TopScore = data.TopScore;
            TopScorePlayerName = data.TopScorePlayerName;
        }
    }

}
