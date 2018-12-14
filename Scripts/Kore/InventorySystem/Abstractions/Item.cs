using UnityEngine;

namespace Kore.InventorySystem
{
    public abstract class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
    }
}
