using UnityEngine;

namespace Kore.InventorySystem
{
    [CreateAssetMenu(menuName = "Kore/InventorySystem/ItemDataStore")]
    public class ItemDataStore : ScriptableObject
    {
        public Item[] data = new Item[0];
    }
}