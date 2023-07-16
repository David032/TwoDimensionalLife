using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwoDLife.Items;
using TwoDLife.Player;
using Unity.Netcode;
using UnityEngine;

namespace TwoDLife.Network
{
    public class LifeNetworkManager : NetworkManager
    {
        public UsableItem startingWeapon;

        private void OnConnectedToServer()
        {
            var player = GameObject.FindGameObjectsWithTag("Player")
                .Select(x => x).FirstOrDefault(x => x.GetComponent<NetworkBehaviour>().IsLocalPlayer);
            if (player != null)
            {
                player.GetComponent<PlayerInventory>().AddUsableItem(startingWeapon);
            }
        }
    }
}