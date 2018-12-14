using UnityEngine;
using Kore.InventorySystem;

namespace Kore
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/InventoryCheck")]
    public class InventoryCheck : ConditionCheck
    {
        public Inventory inventory;
        public Item needItem;
        public int needCount = 1;

        protected override bool Check()
        {
            return inventory.Where(i => i.item == needItem && i.count >= needCount) != null;
        }
    }
}