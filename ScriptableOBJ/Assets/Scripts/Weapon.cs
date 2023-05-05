using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //references
    [SerializeField] WeaponData weaponInfo;
    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = weaponInfo.weaponSprite;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        CharacterDataContainer playerREF = other.GetComponent<CharacterDataContainer>();

        if (playerREF != null && weaponInfo.classeRestriction == playerREF.characterData[playerREF.GetIndexData()].myClass)
        {

            foreach (var item in playerREF.characterData[playerREF.GetIndexData()].weaponDatas)
            {
                if (item.weaponName == weaponInfo.weaponName)
                {
                    return;
                }
            }

            playerREF.AddWeapon(weaponInfo);
            Destroy(gameObject);
        }
    }
}
