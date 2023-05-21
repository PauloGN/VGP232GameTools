using UnityEngine;
using UnityEngine.UI;

public class DataPackingDemo : MonoBehaviour
{
    public GameData gameData;
    public Text outputText;

    public void PackAndEncryptData()
    {
        // Pack and encrypt the GameData object
        DataPacking.PackData(gameData);

        outputText.text = "Packing and encryption completed.";
    }
}