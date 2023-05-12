using UnityEngine;

namespace FoxTool
{
    [CreateAssetMenu(fileName = "New Item", menuName = "FoxTools/Inventory/Item")]
    public class Item : ScriptableObject
    {
        public new string name = "New Item";
        public Sprite icon = null;

        public virtual void Use()
        {
            Debug.Log("Using " + name);
        }
    }
}
