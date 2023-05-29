using System.Collections;
using System.Collections.Generic;
using TwoDLife.Entities;
using Unity.Netcode;
using UnityEngine;

namespace TwoDLife.Interactions
{
    public class Attack : NetworkBehaviour
    {
        public int damage;
        private void Start()
        {
            Invoke(nameof(DestroyObject), 1.5f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsServer || IsHost)
            {
                var entity = collision.GetComponent<Entity>();
                if (entity != null)
                {
                    var health = entity.Health;
                    health.Value -= damage;

                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {

        }

        void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}

