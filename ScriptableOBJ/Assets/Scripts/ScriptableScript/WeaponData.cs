using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public CharClass classeRestriction;
    public string weaponName;
    public string weaponDescription;
    public int weaponDamage;
    public Sprite weaponSprite;
}
