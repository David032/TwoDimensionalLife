using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TwoDLife.Player
{
    public class PlayerToolbarSlot : MonoBehaviour
    {
        [SerializeField]
        Image ItemImage;
        [SerializeField]
        GameObject Slot;
        [SerializeField]
        GameObject ActiveSlot;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ToggleSlot()
        {
            Slot.SetActive(!Slot.activeSelf);
            ActiveSlot.SetActive(!ActiveSlot.activeSelf);
        }

        public void SetSlotImage(Item.Item item)
        {
            ItemImage.sprite = item.Image;
        }

        public void SelectSlot()
        {
            Slot.SetActive(false);
            ActiveSlot.SetActive(true);
        }

        public void DeselectSlot()
        {
            Slot.SetActive(true);
            ActiveSlot.SetActive(false);
        }
    }
}

