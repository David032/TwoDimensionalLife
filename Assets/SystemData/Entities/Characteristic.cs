using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TwoDLife.Entities
{
    public class Characteristic : MonoBehaviour
    {
        public string CharacteristicName;
        int max = 100;
        [SerializeField]
        int current = 0;
        public UnityEvent OnEmpty;
        public UnityEvent OnChange;

        public void SetUp(string name, int max, int current, UnityEvent onEmpty, int value)
        {
            this.name = name;
            this.max = max;
            this.current = current;
            OnEmpty = onEmpty;
        }
        public void SetUp(string CharacteristicName, int startingValue = 100)
        {
            name = CharacteristicName;
            max = startingValue;
            current = startingValue;
        }
        public void SetUp(int startingValue = 100)
        {
            max = startingValue;
            current = startingValue;
        }

        public void Increase(int value)
        {
            current += value;
            OnChange?.Invoke();
            //Sounds, sfx here
        }
        public void Decrease(int value)
        {
            current -= value;
            OnChange?.Invoke();
            //Sounds, sfx here
        }
    }
}

