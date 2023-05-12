using UnityEngine;
using System;
using System.Collections.Generic;

namespace FoxTool
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private int maxStackLimit = 99;
        private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

        public event Action<Item> onItemAdded;
        public event Action<Item> onItemRemoved;

        public int MaxStackLimit => maxStackLimit;

        public bool AddItem(Item item, int quantity = 1)
        {
            if (item == null || quantity <= 0)
                return false;

            int currentQuantity = GetItemCount(item);

            if (currentQuantity >= maxStackLimit)
                return false;

            int availableQuantity = maxStackLimit - currentQuantity;
            int addQuantity = Mathf.Min(quantity, availableQuantity);

            if (inventory.ContainsKey(item))
                inventory[item] += addQuantity;
            else
                inventory.Add(item, addQuantity);

            onItemAdded?.Invoke(item);

            return true;
        }

        public bool RemoveItem(Item item, int quantity = 1)
        {
            if (item == null || quantity <= 0)
                return false;

            if (inventory.ContainsKey(item))
            {
                int currentQuantity = inventory[item];
                int removeQuantity = Mathf.Min(quantity, currentQuantity);

                inventory[item] -= removeQuantity;

                if (inventory[item] <= 0)
                    inventory.Remove(item);

                onItemRemoved?.Invoke(item);

                return true;
            }

            return false;
        }

        public int GetItemCount(Item item)
        {
            if (item == null)
                return 0;

            return inventory.ContainsKey(item) ? inventory[item] : 0;
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(inventory.Keys);
        }

        public void ClearInventory()
        {
            inventory.Clear();
        }
    }
}
