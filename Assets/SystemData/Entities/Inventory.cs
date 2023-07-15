using System.Collections;
using System.Collections.Generic;
using TwoDLife.Item;
using UnityEngine;

namespace TwoDLife.Entities
{
    public class Inventory : MonoBehaviour
    {
        List<Item.Item> items = new();

        public List<Item.Item> GetItems() { return items; }
        public Item.Item GetItem(int index) { return items[index]; }
        public void AddItem(Item.Item item) { items.Add(item); }
    }
}