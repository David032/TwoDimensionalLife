using System.Collections;
using System.Collections.Generic;
using TwoDLife.Entities;
using UnityEngine;

namespace TwoDLife.Item
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Life2D/Item/Potion")]
    public class Potion : ConsumableItem
    {
        public Characteristic CharacteristicAffected;
        public int Amount = 20;


        public void Use(GameObject user)
        {
            user.GetComponent<Entities.Characteristic>().Increase(Amount);
            base.Use(user);
        }
    }
}

