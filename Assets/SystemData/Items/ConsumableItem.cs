using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDLife.Items
{
    public abstract class ConsumableItem : UsableItem
    {
        protected int uses = 3;
        public int Uses
        {
            get => uses;
            set => uses -= value;
        }
    }
}

