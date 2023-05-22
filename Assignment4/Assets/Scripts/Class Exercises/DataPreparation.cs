using UnityEngine;
public interface ISerializable
{
	public object GetSerializable();
}

public class DataPreparation : MonoBehaviour
{
	public ScriptableObject myScriptableObject; // Reference to the ScriptableObject data

	private void Start()
	{
		//Check Serializable
		if (!typeof(ISerializable).IsAssignableFrom(myScriptableObject.GetType()))
        {
			Debug.LogError("Scriptable object does not inherit from ISerializable. Data cannot be Serialized");
			return;
        }
		// Get data from the ScriptableObject
		byte[] serializedData = ScriptableObjectSerializer.SerializeScriptableObject(myScriptableObject as ISerializable);
		// Compress the data
		byte[] compressedData = DataCompression.CompressData(serializedData);

		// Pack the data for sending
		byte[] packedData = BitPacker.PackData(compressedData.Length, compressedData);

		// Now you can send the packedData over the network or perform any required action with it
		// ...

		// Example: Sending the packed data as a debug log
		Debug.Log("Packed Data: " + System.Convert.ToBase64String(packedData));
	}
}
