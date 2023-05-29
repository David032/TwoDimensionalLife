using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDLife.Entities
{
    public class Inventory : MonoBehaviour
    {
        List<Item.Item> items;

        public List<Item.Item> GetItems() { return items; }
    }
}