using System.Collections;
using System.Collections.Generic;
using TwoDLife.Entities;
using TwoDLife.Items;
using TwoDLife.Player;
using UnityEngine;

namespace TwoDLife.World
{
    public class Container : MonoBehaviour
    {
        //Instancing won't work until identity is implemented
        public bool isInstanced = false;
        public List<Item> Contents;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Interact(collision);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Interact(collision);
        }

        private void Interact(Collider2D collision)
        {
            var interactingObject = collision.gameObject;
            if (collision != null && interactingObject.GetComponent<Entity>())
            {
                if (interactingObject.CompareTag("Player") && interactingObject.GetComponent<PlayerControls>().isInteracting)
                {
                    var inventory = interactingObject.GetComponent<PlayerInventory>();
                    foreach (var item in Contents)
                    {
                        if (item is UsableItem itemUsable)
                        {
                            inventory.AddUsableItem(itemUsable);
                        }
                        else
                        {
                            inventory.AddItem(item);
                        }
                    }
                    //Need better system for instancing loot
                    Contents.Clear();
                }
            }
        }
    }
}

