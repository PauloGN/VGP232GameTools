using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Variables

    public List<Weapon> weapons = new List<Weapon>();
    public int itemSlots;
    [SerializeField] GameObject bagReference;

   #endregion


}
