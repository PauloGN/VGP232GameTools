using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGameScript : MonoBehaviour
{

    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public SaveGameContainer sgContainer;

    public void SaveBinaryToFile()
    {
        //To save in a directory, it must ve created first in case it does not exist yet
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
    
        //The formatter will convert our unity data type into a binary file
        BinaryFormatter bf = new BinaryFormatter();

        //choose the save location
        FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");

        //Write our C# Unity fame data type to binary file
        bf.Serialize(saveFile, sgContainer);
        saveFile.Close();

        Debug.Log("Game saved to" + Directory.GetCurrentDirectory().ToString() + directoryName + ".bin");

    }
}
