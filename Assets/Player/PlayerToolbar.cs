using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TwoDLife.Player
{
    public class PlayerToolbar : MonoBehaviour
    {
        PlayerToolbarSlot[] playerToolbarSlots = null;
        // Start is called before the first frame update
        void Start()
        {
            playerToolbarSlots = GetComponentsInChildren<PlayerToolbarSlot>();
            var slot1 = playerToolbarSlots.Select(x => x).Where(x => x.gameObject.name == "ToolbarSlot1").First();
            slot1.ToggleSlot();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetActiveSlot(int slot)
        {
            foreach (var item in playerToolbarSlots)
            {
                item.DeselectSlot();
            }
            var slotToActivate = playerToolbarSlots.Select(x => x).Where(x => x.gameObject.name == "ToolbarSlot" + slot).First();
            slotToActivate.SelectSlot();

        }
    }
}

