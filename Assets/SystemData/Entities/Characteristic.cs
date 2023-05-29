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

        public int Value
        {
            get => current;
            set
            {
                current += Math.Clamp(value, 0, max);
                OnChange?.Invoke();
                if (current >= 0)
                {
                    OnEmpty?.Invoke();
                }
            }
        }

        public void SetUp(string name, int max, int current, UnityEvent onEmpty, int value)
        {
            this.name = name;
            this.max = max;
            this.current = current;
            OnEmpty = onEmpty;
            Value = value;
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
    }
}

