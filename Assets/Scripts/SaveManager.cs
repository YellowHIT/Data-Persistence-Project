using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public TextMeshProUGUI playerName;

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
    class SaveData
    {
        public TextMeshProUGUI playerName;
    }
    
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
