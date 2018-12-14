using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Kore.InventorySystem
{
    [CreateAssetMenu(menuName = "Kore/InventorySystem/Inventory")]
    public class Inventory : ScriptableObject
    {
        public List<InventoryItem> inventoryItems = new List<InventoryItem>();

        public List<Item> Items => inventoryItems.Select(i => i.item).ToList();
        public int Count => inventoryItems.Count;
        public bool Empty => Count <= 0;

        public void Add(Item itemToAdd)
        {
            var iitem = inventoryItems.FirstOrDefault(i => i.item == itemToAdd);

            if (iitem != null)
            {
                iitem.count++;
            }
            else
            {
                inventoryItems.Add(new InventoryItem(itemToAdd));
            }
        }

        public void Remove(Item itemToRemove)
        {
            var index = inventoryItems.FindIndex(i => i.item == itemToRemove);

            if (index > -1 && index < inventoryItems.Count)
            {
                inventoryItems.RemoveAt(index);
            }
        }

        public IEnumerable<InventoryItem> Where(Func<InventoryItem, bool> predicate)
        {
            return inventoryItems.Where(predicate);
        }

        public bool Contains(Item item)
        {
            var found = inventoryItems.FirstOrDefault(i => i.item == item && i.count > 0);
            return found.count > 0;
        }

        [Serializable]
        public class InventoryItem
        {
            public Item item;
            public int count;

            public InventoryItem(Item item, int count = 1)
            {
                this.item = item;
                this.count = count;
            }
        }
    }
}
