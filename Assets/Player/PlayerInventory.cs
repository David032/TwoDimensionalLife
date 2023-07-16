using System.Collections;
using System.Collections.Generic;
using TwoDLife.Entities;
using UnityEngine;

namespace TwoDLife.Player
{
    public class PlayerInventory : Inventory
    {
        int activeSlot = 1;
        public int ActiveSlot
        {
            get => activeSlot;
            set
            {
                activeSlot = value;
                toolbar.SetActiveSlot(activeSlot);
            }
        }

        PlayerToolbar toolbar;

        public List<Item.Item> UsableItems;
        public Item.Item EquippedItem;

        private void Start()
        {
            toolbar = GetComponentInChildren<PlayerToolbar>();
        }

    }
}

