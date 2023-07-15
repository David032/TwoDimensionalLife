using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDLife.Item
{
    public abstract class ConsumableItem : Item, IUsableItem
    {
        int uses = 3;
        public int Uses
        {
            get => uses;
            set => uses -= value;
        }

        public void Use(GameObject user)
        {
            uses -= 1;
        }
    }
}

