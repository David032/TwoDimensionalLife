using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDLife.Item
{
    public abstract class UsableItem : Item
    {
        public float Speed;
        [SerializeField]
        int MaxDurability;
        public int CurrentDurability
        {
            get => _CurrentDurability;
            set
            {
                _CurrentDurability += value;
                if (_CurrentDurability >= 0)
                {
                    DestroyItem();
                }
            }
        }
        int _CurrentDurability;

        void Awake()
        {
            _CurrentDurability = MaxDurability;
        }

        void DestroyItem()
        {
            Destroy(this);
        }
    }
}

