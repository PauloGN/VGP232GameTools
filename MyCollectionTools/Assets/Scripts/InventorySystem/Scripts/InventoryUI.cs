using UnityEngine;
using UnityEngine.UI;

namespace FoxTool
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventorySlotPrefab;
        [SerializeField] private Transform inventorySlotsParent;
        [SerializeField] private Vector2 slotPadding = new Vector2(10f, 10f);
        [SerializeField] private int collumns;

        private InventorySystem inventorySystem;

        private void Start()
        {
            inventorySystem = FindObjectOfType<InventorySystem>();

            inventorySystem.onItemAdded += OnItemAdded;
            inventorySystem.onItemRemoved += OnItemRemoved;

            RefreshInventoryUI(collumns);
        }

        private void OnDestroy()
        {
            if (inventorySystem != null)
            {
                inventorySystem.onItemAdded -= OnItemAdded;
                inventorySystem.onItemRemoved -= OnItemRemoved;
            }
        }

        private void OnItemAdded(Item item)
        {
            RefreshInventoryUI(collumns);
        }

        private void OnItemRemoved(Item item)
        {
            RefreshInventoryUI(collumns);
        }

        private void RefreshInventoryUI(int columns)
        {
            // Clear existing slots
            foreach (Transform child in inventorySlotsParent)
            {
                Destroy(child.gameObject);
            }

            int rowCount = Mathf.CeilToInt((float)inventorySystem.GetAllItems().Count / columns);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = i * columns + j;
                    if (index >= inventorySystem.GetAllItems().Count)
                        return;

                    Item item = inventorySystem.GetAllItems()[index];
                    int quantity = inventorySystem.GetItemCount(item);

                    GameObject slot = Instantiate(inventorySlotPrefab, inventorySlotsParent);
                    RectTransform slotTransform = slot.GetComponent<RectTransform>();
                    slotTransform.anchoredPosition = new Vector2(j * (slotTransform.sizeDelta.x + slotPadding.x), -i * (slotTransform.sizeDelta.y + slotPadding.y));

                    UpdateSlotUI(slot, item, quantity);
                }
            }
        }


        private void UpdateSlotUI(GameObject slot, Item item, int quantity)
        {
            Image iconImage = slot.GetComponentInChildren<Image>();
            Text quantityText = slot.GetComponentInChildren<Text>();

            iconImage.sprite = item.icon;
            quantityText.text = quantity.ToString();
        }
    }
}

