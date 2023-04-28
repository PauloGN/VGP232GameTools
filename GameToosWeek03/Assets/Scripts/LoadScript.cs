using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class LoadScript : MonoBehaviour
{

    public string saveName = "savedGame";
    public string directoryName = "Saves";

    [SerializeField] TMP_Text healthInfo;
    [SerializeField] TMP_Text charNameInfo;
    [SerializeField] TMP_Text weaponInfo;
    [SerializeField] TMP_Text armorInfo;
    [SerializeField] TMP_Text skillInfo;

    public void LoadFromBinaryFile()
    {    
        //Converts binary file back into readable data for Unity gam
        BinaryFormatter formatter = new BinaryFormatter();

        // choose the saved file to open
        FileStream saveFile = File.Open(directoryName + "/" + saveName + ".bin", FileMode.Open);
    
        //Convert the file data into SaveGameData format for use in game
        SaveGameContainer SGContainer = (SaveGameContainer) formatter.Deserialize(saveFile);
        LoadInfoOnScreeen(SGContainer);


        saveFile.Close();
    
    }


    void LoadInfoOnScreeen(SaveGameContainer sg)
    {
        healthInfo.text = "Health: " + sg.health.ToString();
        charNameInfo.text = "Name: " + sg.charName.ToString();
        weaponInfo.text = "Weapon: " + sg.weapon.weaponName;
        armorInfo.text =  "Armor: " + sg.armor.armorName;
        skillInfo.text =  "Skill: " + sg.skill.skillName;
    }


}
