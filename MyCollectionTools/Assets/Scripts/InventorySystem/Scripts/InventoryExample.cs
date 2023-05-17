using UnityEngine;

namespace FoxTool
{
    public class InventoryExample : MonoBehaviour
    {
        private InventorySystem inventorySystem;

        [SerializeField] private Item[] testItems;
        [SerializeField] private KeyCode addItemKey = KeyCode.A;
        [SerializeField] private KeyCode removeItemKey = KeyCode.R;

        private void Start()
        {
            inventorySystem = GetComponent<InventorySystem>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(addItemKey))
            {
                AddRandomItem();
            }
            else if (Input.GetKeyDown(removeItemKey))
            {
                RemoveRandomItem();
            }
        }

        private void AddRandomItem()
        {
            if (testItems.Length == 0)
            {
                Debug.LogWarning("No test items assigned.");
                return;
            }

            Item randomItem = testItems[Random.Range(0, testItems.Length)];
            int quantity = Random.Range(1, 3); // Random quantity between 1 and 2

            inventorySystem.AddItem(randomItem, quantity);
        }

        private void RemoveRandomItem()
        {
            if (inventorySystem.GetAllItems().Count == 0)
            {
                Debug.LogWarning("Inventory is empty.");
                return;
            }

            Item randomItem = inventorySystem.GetAllItems()[Random.Range(0, inventorySystem.GetAllItems().Count)];
            int quantity = 1;

            inventorySystem.RemoveItem(randomItem, quantity);
        }
    }
}
