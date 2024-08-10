using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataJSON : MonoBehaviour
{
    public HAGNData hagnData;

    void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(hagnData);
        File.WriteAllText(Application.persistentDataPath + "SaveData.json", json);
        
    }
    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath + "SaveData.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            hagnData = JsonUtility.FromJson<HAGNData>(json);
        }
        else
        {
            hagnData = new HAGNData();
        }
    }
    [ContextMenu("DeleteSave")]
    public void DeleteSave()
    {
        hagnData.hagnCoin = 0;
    }
    
    [System.Serializable]
    public class HAGNData
    {
        public int hagnCoin = Coins.Instance.GetCoinsInfo();
    }
}