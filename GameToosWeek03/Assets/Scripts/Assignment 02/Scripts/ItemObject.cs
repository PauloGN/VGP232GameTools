using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Defalt
}

public abstract class ItemObject : ScriptableObject
{
    //prefab is going to hold the display for the item once added in the inventory
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}

/*
 * This class is going to be the base and extandable class for creating my Items
 * Food
 * Equipment
 * Weapons 
*/