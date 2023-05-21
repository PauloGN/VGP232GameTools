using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScriptableObjectSerializer
{
	public static byte[] SerializeGenaric(object obj)
    {
		BinaryFormatter formatter = new BinaryFormatter();
		using (MemoryStream stream = new MemoryStream())
		{
			formatter.Serialize(stream, obj);
			return stream.ToArray();
		}
	}
	public static byte[] SerializeScriptableObject(ISerializable scriptableObject)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		using (MemoryStream stream = new MemoryStream())
		{
			formatter.Serialize(stream, scriptableObject.GetSerializable());
			return stream.ToArray();
		}
	}

	public static T DeserializeScriptableObject<T>(byte[] data) where T : ScriptableObject
	{
		BinaryFormatter formatter = new BinaryFormatter();
		using (MemoryStream stream = new MemoryStream(data))
		{
			return formatter.Deserialize(stream) as T;
		}
	}
}
