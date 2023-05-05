using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdatePanelInfo : MonoBehaviour
{

    [SerializeField] CharacterDataContainer myCharacterDataContainer;
    public TMP_Text myChass;
    public TMP_Text magicAttack;
    public TMP_Text magicDef;
    public TMP_Text physicalAttack;
    public TMP_Text physicalDef;
    public TMP_Text soulLevel;
    public TMP_Text weaponEquiped;


    public void DisplayInfoUpdated()
    {
    
        myChass.text = myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].myClass.ToString();
        magicAttack.text = "Magic Power: " + myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].magicPower.ToString();
        magicDef.text = "Magic Def: " + myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].magicDefense.ToString();
        physicalAttack.text = "Physical Attack: " + myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].physicalPower.ToString();
        physicalDef.text = "Physical Def: " + myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].PhysicalDefense.ToString();
        soulLevel.text = "Soul Level: " + myCharacterDataContainer.characterData[myCharacterDataContainer.GetIndexData()].soulLevel.ToString();

        weaponEquiped.text = (myCharacterDataContainer.equippedWeaponData != null && myCharacterDataContainer.isWeaponEquiped) ? myCharacterDataContainer.equippedWeaponData.weaponName : "No Weapon Equiped";

    }


}
