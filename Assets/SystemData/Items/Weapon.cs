using System.Collections;
using System.Collections.Generic;
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
            var facing = user.GetComponent<PlayerControls>().ClickFacing;
            var playerPosition = user.transform.position;
            switch (facing)
            {
                case Facing.Up:
                    var upSide = playerPosition + new Vector3(0, 0.16f, 0);
                    var upGo = Instantiate(DamageObject, upSide, Quaternion.identity);
                    upGo.GetComponent<Attack>().damage = Damage;
                    upGo.GetComponent<NetworkObject>().Spawn();
                    break;
                case Facing.Down:
                    var downSide = playerPosition + new Vector3(0, -0.16f, 0);
                    var downGo = Instantiate(DamageObject, downSide, Quaternion.identity);
                    downGo.GetComponent<Attack>().damage = Damage;
                    downGo.GetComponent<NetworkObject>().Spawn();
                    break;
                case Facing.Left:
                    var leftSide = playerPosition + new Vector3(-0.16f, 0, 0);
                    var go = Instantiate(DamageObject, leftSide, Quaternion.identity);
                    go.GetComponent<Attack>().damage = Damage;
                    go.GetComponent<NetworkObject>().Spawn();
                    break;
                case Facing.Right:
                    var rightSide = playerPosition + new Vector3(0.16f, 0, 0);
                    var rightGo = Instantiate(DamageObject, rightSide, Quaternion.identity);
                    rightGo.GetComponent<Attack>().damage = Damage;
                    rightGo.GetComponent<NetworkObject>().Spawn();
                    break;
                default:
                    break;
            }

        }
    }
}

