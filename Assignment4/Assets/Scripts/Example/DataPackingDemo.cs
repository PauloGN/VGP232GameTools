using UnityEngine;
using UnityEngine.UI;

public class DataPackingDemo : MonoBehaviour
{
    public GameDt_S gameData;
    public Text outputText;

    public void PackAndEncryptData()
    {
        // Pack and encrypt the GameData object
        DataPacking.PackData(gameData.gd);

        outputText.text = "Packing and encryption completed.";
    }
}