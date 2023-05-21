using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataPacking
{
    public static void PackData(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();

        formatter.Serialize(memoryStream, gameData);
        byte[] dataBytes = memoryStream.ToArray();
        byte[] encryptedData = DataEncryption.EncryptData(dataBytes);

        File.WriteAllBytes(Application.persistentDataPath + "/packedData.dat", encryptedData);

        memoryStream.Close();
    }
}
