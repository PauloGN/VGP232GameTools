using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string weaponName;
    public int dmg;
    public int weight;
    [SerializeField] int myInt;
    [SerializeField] Vector3 pos;
    [SerializeField] float attackSpeed;
}
