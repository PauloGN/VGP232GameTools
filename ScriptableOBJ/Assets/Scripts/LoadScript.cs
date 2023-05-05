using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    public string saveName = "savedGame";
    public string directoryName = "Saves";

   string magicAttack;
   string PhysicalAttack;
   string MagicDef;
   string PhysicalDef;
   string myClass;

    public void LoadFromBinaryFile()
    {
        //Converts binary file back into readable data for Unity gam
        BinaryFormatter formatter = new BinaryFormatter();

        // choose the saved file to open
        FileStream saveFile = File.Open(directoryName + "/" + saveName + ".bin", FileMode.Open);

        //Convert the file data into SaveGameData format for use in game
        ContainerForSaving SGContainer = (ContainerForSaving)formatter.Deserialize(saveFile);


        saveFile.Close();
        LoadInfoOnScreeen(SGContainer);

    }

    void LoadInfoOnScreeen(ContainerForSaving sg)
    {
       magicAttack = "Magic Power: " + sg.magicPower.ToString();
       PhysicalAttack = "Physical Power: " + sg.physicalPower.ToString();
       MagicDef = "MagicDef: " + sg.magicDefense.ToString();
       PhysicalDef = "PhysicalDef: " + sg.PhysicalDefense.ToString();
       myClass = "MyClass: " + sg.myClass.ToString();

        Debug.Log("Data saved on the class: " + myClass + "\n" +  magicAttack + "\n" + PhysicalAttack + "\n" + MagicDef + "\n" + PhysicalDef );

    }

}
