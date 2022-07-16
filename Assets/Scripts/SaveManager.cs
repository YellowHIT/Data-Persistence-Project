using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public TextMeshProUGUI playerName;

    public string name;

    public int temp;

    public int highScore;
    public string playerHighScore;

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

    //for the save files
   [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int score;
    }
    
    public void SaveName(int point)
    {
        LoadName();
        
        SaveData data = new SaveData();
        if(GameObject.Find("Text") != null)
        {
            playerName = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        }
        name = playerName.text;
        data.playerName = name;
        Debug.Log(Application.persistentDataPath + "/savefile.json");


        data.score = point;
        Debug.Log(data);
        
        string json = JsonUtility.ToJson(data);

        Debug.Log(playerName);

        if(highScore < data.score)
        {
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.score;
            playerHighScore = data.playerName;
        }
    }

    public int GetScore()
    {
        return highScore;
    }

    public string GetName()
    {
        return playerHighScore;
    }
}
