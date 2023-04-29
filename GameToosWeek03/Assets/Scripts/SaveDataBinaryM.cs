using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveDataBinaryM
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveData.txt";

    public static void Save(GameData gd)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

       // string json = JsonUtility.ToJson(gd);
       // File.WriteAllText(dir + fileName, json);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dir + fileName);
        bf.Serialize(file, gd);
        file.Close();

        Debug.Log("Saved in" + dir);
    }

    public static GameData Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        GameData gd = new GameData();

        if (File.Exists(fullpath))
        {
            // string json = File.ReadAllText(fullpath);
            // gd = JsonUtility.FromJson<GameData>(json);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fullpath, FileMode.Open);
            gd = (GameData)bf.Deserialize(file);
        }
        else
        {
            Debug.Log("Sace does not exist");
        }

        return gd;
    }

}
