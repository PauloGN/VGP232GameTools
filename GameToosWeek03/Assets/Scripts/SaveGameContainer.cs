
using System;
using UnityEngine;

[Serializable]
public struct SaveGameContainer
{
    public int health;
    public string charName;
    public Weapon weapon;
    public Armor armor;
    public Skill skill;
}
