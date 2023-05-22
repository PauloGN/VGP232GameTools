using System;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    public  string charName;
    public int Score;
    public int Level;
    public float health;
}

public static class DataSerialization
{
    public static byte[] Serialize(GameData data)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(data.Score);
            writer.Write(data.Level);
            return stream.ToArray();
        }
    }

    public static GameData Deserialize(byte[] serializedData)
    {
        using (MemoryStream stream = new MemoryStream(serializedData))
        {
            BinaryReader reader = new BinaryReader(stream);
            GameData data = new GameData();
            data.Score = reader.ReadInt32();
            data.Level = reader.ReadInt32();
            return data;
        }
    }
}

