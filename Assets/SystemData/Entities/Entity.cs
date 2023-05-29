using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Netcode;

namespace TwoDLife.Entities
{
    public class Entity : NetworkBehaviour
    {

        public Characteristic Health;
        public GameObject DamageIndicator;

        private void Awake()
        {
            Health = GetComponents<Characteristic>().Where(x => x.CharacteristicName == "Health").First();
            Health.SetUp();
            Health.OnChange.AddListener(FlashDamage);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void FlashDamage()
        {
            StartCoroutine("ShowDamageIndicator");
        }

        IEnumerator ShowDamageIndicator()
        {
            DamageIndicator.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            DamageIndicator.SetActive(false);
        }
    }
}