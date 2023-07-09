using System.Collections;
using System.Collections.Generic;
using TwoDLife.Entities;
using TwoDLife.Interactions;
using TwoDLife.Player;
using Unity.Netcode;
using UnityEngine;

namespace TwoDLife.Item
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Life2D/Item/Weapon")]
    public class Weapon : UsableItem, IUsableItem
    {
        public int Damage;
        public GameObject DamageObject;

        public void Use(GameObject user)
        {
            //Will need reworkign for AI
            var facing = user.GetComponent<PlayerControls>().ClickFacing;
            var playerPosition = user.transform.position;

            GameObject go;
            switch (facing)
            {
                case Facing.Up:
                    var upSide = playerPosition + new Vector3(0, 0.16f, 0);
                    go = Instantiate(DamageObject, upSide, Quaternion.identity);
                    ConfigureAttack(go, 270, user);
                    break;
                case Facing.Down:
                    var downSide = playerPosition + new Vector3(0, -0.16f, 0);
                    go = Instantiate(DamageObject, downSide, Quaternion.identity);
                    ConfigureAttack(go, 90, user);
                    break;
                case Facing.Left:
                    var leftSide = playerPosition + new Vector3(-0.16f, 0, 0);
                    go = Instantiate(DamageObject, leftSide, Quaternion.identity);
                    ConfigureAttack(go, 180, user);
                    break;
                case Facing.Right:
                    var rightSide = playerPosition + new Vector3(0.16f, 0, 0);
                    go = Instantiate(DamageObject, rightSide, Quaternion.identity);
                    ConfigureAttack(go, 0, user);
                    break;
                default:
                    break;
            }

        }

        private void ConfigureAttack(GameObject go, int rotation, GameObject user)
        {
            go.GetComponent<Attack>().damage = Damage;
            go.GetComponent<NetworkObject>().Spawn();
            var particleSystem = go.GetComponentInChildren<ParticleSystem>().main;
            particleSystem.startRotation = rotation * Mathf.Deg2Rad;
            go.GetComponent<Attack>().SpawnedEntity = user.GetComponent<Entity>();
        }
    }
}

