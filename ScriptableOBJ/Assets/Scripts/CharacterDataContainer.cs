using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.U2D.Animation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum CharClass
{
    CC_None = -1,
    CC_Warrior,
    CC_Mage,
    CC_Barbarian
}

public class CharacterDataContainer : MonoBehaviour
{
    public UpdatePanelInfo updatePanel;
    public SpriteRenderer spriteREF = null;
    public SpriteRenderer spriteWeaponREF = null;
    public CharacterData[] characterData;
    int indexData = 0;
    [HideInInspector]
    public WeaponData equippedWeaponData;
    [HideInInspector]
    public bool isWeaponEquiped = false;


    private void Awake()
    {
        spriteREF.color = characterData[indexData].color;
        updatePanel.DisplayInfoUpdated();
    }

    private void OnApplicationQuit()
    {
        foreach (var item in characterData)
        {
            item.ResetData();
        }
    }

    public void AddWeapon(WeaponData weaponInf)
    {
        characterData[indexData].weaponDatas.Add(weaponInf);
    }

    public void  IncreaseSoulPower(float value)
    {
        characterData[indexData].soulLevel += value;
        characterData[indexData].UpdatePower();
        updatePanel.DisplayInfoUpdated();
    }

    public void SetIndexData(CharClass myClass)
    {
        indexData = Convert.ToInt32(myClass);
    }

    public int GetIndexData()
    { 
        return indexData;
    }

    public bool EquippeWeapon()
    {

        foreach(var item in characterData[indexData].weaponDatas)
        {
            if(item.classeRestriction == characterData[indexData].myClass)
            {
                equippedWeaponData = item;
                if(equippedWeaponData != null && !isWeaponEquiped)
                {
                    isWeaponEquiped = true;
                    spriteWeaponREF.sprite = equippedWeaponData.weaponSprite;
                    characterData[indexData].WeaponEquipped(equippedWeaponData.weaponDamage);
                    updatePanel.DisplayInfoUpdated();
                    return isWeaponEquiped;
                }
            }
        }

        return isWeaponEquiped;

    }
    public bool UnequipWeapon()
    {
        if (equippedWeaponData != null && isWeaponEquiped)
        {
           isWeaponEquiped = false;
           characterData[indexData].WeaponUnequipped(equippedWeaponData.weaponDamage);
        }
        spriteWeaponREF.sprite = null;
        return isWeaponEquiped;
    }

    public void ChangeCharacter()
    {
       UnequipWeapon();
       SetIndexData((CharClass)((GetIndexData() + 1) % characterData.Length));
       spriteREF.color = characterData[GetIndexData()].color;
       updatePanel.DisplayInfoUpdated();
    }

}

[CustomEditor(typeof(CharacterDataContainer))]
public class InspectorTools : Editor
{

    private bool isWeaponEquipped;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CharacterDataContainer container = (CharacterDataContainer)target;
        if (GUILayout.Button("Change Character"))
        {
            container.ChangeCharacter();
        }

        if (GUILayout.Button("Change Weapon"))
        {
            if (!isWeaponEquipped)
            {
                isWeaponEquipped = container.EquippeWeapon();
            }
            else
            {
                isWeaponEquipped = container.UnequipWeapon();
                container.updatePanel.DisplayInfoUpdated();
            }
        }

        GUILayout.Label(container.characterData[container.GetIndexData()].myClass.ToString());      
    }

}