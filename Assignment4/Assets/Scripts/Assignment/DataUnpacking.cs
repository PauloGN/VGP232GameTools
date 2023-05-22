using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataUnpacking
{
    public static GameData UnpackData()
    {
        string filePath = Application.persistentDataPath + "/packedData.dat";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Open(filePath, FileMode.Open);

            byte[] encryptedData = new byte[fileStream.Length];
            fileStream.Read(encryptedData, 0, (int)fileStream.Length);

            byte[] decryptedData = DataEncryption.DecryptData(encryptedData);
            GameData gameData = (GameData)formatter.Deserialize(new MemoryStream(decryptedData));

            fileStream.Close();

            return gameData;
        }
        else
        {
            Debug.LogError("Packed data file does not exist.");
            return null;
        }
    }
}