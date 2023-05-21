using UnityEngine;
using UnityEngine.UI;

public class DataUnpackingDemo : MonoBehaviour
{
    public Text outputText;

    public void UnpackAndDecryptData()
    {
        // Unpack and decrypt the data
        GameData unpackedData = DataUnpacking.UnpackData();

        if (unpackedData != null)
        {
            // Access and display the unpacked data
            outputText.text = "Unpacked Name: " + unpackedData.charName + "\n" +
                              "Unpacked Score: " + unpackedData.Score + "\n" +
                              "Unpacked Level: " + unpackedData.Level + "\n" +
                              "Unpacked Health: " + unpackedData.health;
        }
    }
}
