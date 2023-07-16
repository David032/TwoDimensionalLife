using System.Collections;
using System.Collections.Generic;
using TwoDLife.Items;
using UnityEngine;

namespace TwoDLife.Entities
{
    public class Inventory : MonoBehaviour
    {
        protected List<Item> items = new();

        public List<Item> GetItems() { return items; }
        public Item GetItem(int index) { return items[index]; }
        public void AddItem(Item item) { items.Add(item); }
    }
}