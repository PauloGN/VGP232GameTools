using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveDataManager
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

        string json = JsonUtility.ToJson(gd);
        File.WriteAllText(dir + fileName, json);

        Debug.Log("Saved in" + dir);

    }

    public static GameData Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        GameData gd = new GameData();

        if (File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            gd = JsonUtility.FromJson<GameData>(json);

        }
        else
        {
            Debug.Log("Sace does not exist");
        }

        return gd;
    }

}

