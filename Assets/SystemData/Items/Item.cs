using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDLife.Items
{
    interface IUsableItem
    {
        void Use(GameObject user);
    }

    [CreateAssetMenu(fileName = "Item", menuName = "Life2D/Item/Item")]
    public class Item : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Image;
    }
}

