using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class CharacterData : ScriptableObject
{
    public CharClass myClass;

    public float magicPower;
    public float magicDefense;

    public float physicalPower;
    public float PhysicalDefense;

    public float soulLevel;

    public List<WeaponData> weaponDatas = new List<WeaponData>();

    public Color color;


    public void UpdatePower()
    {

        switch (myClass)
        {
            case CharClass.CC_Warrior:

                magicDefense += soulLevel + (soulLevel * soulLevel);
                magicPower += (soulLevel * soulLevel);
                PhysicalDefense += (soulLevel + soulLevel) * (soulLevel);
                physicalPower += (soulLevel * soulLevel) * soulLevel;

                break;

            case CharClass.CC_Mage:

                PhysicalDefense += soulLevel + (soulLevel * soulLevel);
                physicalPower += (soulLevel * soulLevel);
                magicDefense += (soulLevel + soulLevel) * (soulLevel);
                magicPower += (soulLevel * soulLevel) * soulLevel;

                break; 
        }

    }

    public void WeaponEquipped(float value)
    {
        switch (myClass)
        {
            case CharClass.CC_Warrior:

                magicDefense += (value * 0.5f);
                magicPower += (value * 0.5f);
                PhysicalDefense += (value);
                physicalPower += (value);

                break;

            case CharClass.CC_Mage:

                PhysicalDefense += (value * 0.5f);
                physicalPower += (value * 0.5f);
                magicDefense += (value);
                magicPower += (value);

                break;
        }

    }

    public void WeaponUnequipped(float value)
    {
        switch (myClass)
        {
            case CharClass.CC_Warrior:

                magicDefense -= (value * 0.5f);
                magicPower -= (value * 0.5f);
                PhysicalDefense -= (value);
                physicalPower -= (value);

                break;

            case CharClass.CC_Mage:

                PhysicalDefense -= (value * 0.5f);
                physicalPower -= (value * 0.5f);
                magicDefense -= (value);
                magicPower -= (value);

                break;
        }
    }

    public void ResetData()
    {
        weaponDatas.Clear();
        soulLevel = 0.0f;

        switch (myClass)
        {
            case CharClass.CC_None:
                magicPower = 0.0f;
                magicDefense = 0.0f;
                physicalPower = 0.0f;
                PhysicalDefense = 0.0f;
                break;
            case CharClass.CC_Warrior:
                magicPower = 10.0f;
                magicDefense = 10.0f;
                physicalPower = 35.0f;
                PhysicalDefense = 35.0f;
                break;
            case CharClass.CC_Mage:
                magicPower = 35.0f;
                magicDefense = 35.0f;
                physicalPower = 10.0f;
                PhysicalDefense = 10.0f;
                break;
            default:
                break;
        }
    }

}
