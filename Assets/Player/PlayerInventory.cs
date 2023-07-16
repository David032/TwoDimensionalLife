using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwoDLife.Entities;
using TwoDLife.Items;
using UnityEngine;
using static UnityEditor.Progress;
using Item = TwoDLife.Items.Item;

namespace TwoDLife.Player
{
    public class InventorySlot
    {
        public int slotId;
        public UsableItem item;

        public InventorySlot(int slotNumber, UsableItem initalItem)
        {
            slotId = slotNumber;
            item = initalItem;
        }
    }

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
                var slot = usableItems.Select(x => x).Where(x => x.slotId == activeSlot).First();
                print(slot);
                equippedItem = slot.item;
            }
        }

        private UsableItem equippedItem;

        public UsableItem EquippedItem => equippedItem;


        PlayerToolbar toolbar;

        List<InventorySlot> usableItems = new()
        {
            new InventorySlot(1, null),
            new InventorySlot(2, null),
            new InventorySlot(3, null),
            new InventorySlot(4, null),
            new InventorySlot(5, null)
        };

        private void Start()
        {
            toolbar = GetComponentInChildren<PlayerToolbar>();
        }

        public List<InventorySlot> GetUsableItems() { return usableItems; }

        public void AddUsableItem(UsableItem item)
        {
            var slotToBeFilled = usableItems.Select(x => x).Where(x => x.item == null).FirstOrDefault();
            slotToBeFilled.item = item;
            print(slotToBeFilled);

            //Doesn't actually seem to be setting it to usableItems :(
            var slot = toolbar.GetPlayerToolbarSlots().Select(x => x).Where(x => x.gameObject.name == "ToolbarSlot" + slotToBeFilled.slotId).FirstOrDefault();
            slot.SetSlotImage(item);
            //No idea how this'll handle more than 5 usable items
        }

        public void RemoveUsableItem(int slot)
        {
            var slotToEmpty = usableItems.Select(x => x).Where(x => x.slotId == slot).FirstOrDefault();
            //Drop function here
            slotToEmpty.item = null;
        }

        public new Item GetItem(int index) { return items[index]; }
        public new void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}

