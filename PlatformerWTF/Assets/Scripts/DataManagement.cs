using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManagement : MonoBehaviour {

    public static DataManagement datamanagement;
    public int highscore;

    void Awake()
    {
        if (datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        }
        else if(datamanagement!=this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/gameInfo.dat");//creates file
        GameData data = new GameData();
        data.highScore = highscore;
        binaryFormatter.Serialize(file,data);
        file.Close();
    }

    public void LoadData()
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",FileMode.Open);
            GameData data = (GameData)binForm.Deserialize(file);
            file.Close();
            highscore = data.highScore;
            
            
        }
    }

}
[Serializable]
class GameData
{
    public int highScore;

}
