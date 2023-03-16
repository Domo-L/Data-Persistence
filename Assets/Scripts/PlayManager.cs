using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;
    public string bName;
    public int b_Points;

    public string userName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTopScore();
    }
    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bName = data.Name;
            b_Points = data.Score;
        }
    }
    public void SaveTopScore()
    {
        SaveData data = new SaveData();
        data.Name = bName;
        data.Score = b_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
class SaveData
{
    public string Name;
    public int Score;
}