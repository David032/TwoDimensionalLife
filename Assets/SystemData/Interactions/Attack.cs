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
        public Entity SpawnedEntity;
        public bool canDamageSelf = false;

        private void Start()
        {
            Invoke(nameof(DestroyObject), 0.25f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsServer || IsHost)
            {
                var entity = collision.GetComponent<Entity>();
                bool isSelfAttack = entity == SpawnedEntity;

                if (entity != null)
                {
                    if ((isSelfAttack && canDamageSelf) || (!canDamageSelf && !isSelfAttack))
                    {
                        var health = entity.Health;
                        health.Value -= damage;
                        DestroyObject();
                    }
                }
            }
        }

        void CheckOverlap()
        {

        }

        void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}

