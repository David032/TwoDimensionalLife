using System.Collections;
using System.Collections.Generic;
using TwoDLife.Item;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TwoDLife.Player
{
    public class PlayerControls : NetworkBehaviour
    {
        public ParticleSystem PlayerMovementEffect;
        //Variables
        Vector2 move;
        public bool canMove = true;
        public bool canUse = true;
        public float playerSpeed = 1f;
        public Facing ClickFacing;
        //Properties
        Rigidbody2D playerRigid;
        BoxCollider2D playerCollider;
        PlayerInventory playerInventory;

        void Start()
        {
            playerRigid = GetComponentInChildren<Rigidbody2D>();
            playerCollider = GetComponentInChildren<BoxCollider2D>();
            playerInventory = GetComponent<PlayerInventory>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsLocalPlayer)
            {
                return;
            }
        }

        private void FixedUpdate()
        {
            if (move.sqrMagnitude < 0.01)
            {
                return;
            }
            else
            {
                float scaledMoveSpeed = playerSpeed * Time.deltaTime;
                var playerMove = new Vector3(move.x, move.y, 0) * scaledMoveSpeed;
                playerRigid.MovePosition(transform.position + playerMove);
            }
        }

        #region Input Events
        public void OnMove(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
            if (move == Vector2.zero)
            {
                PlayerMovementEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
            else
            {
                PlayerMovementEffect.Play();
            }
        }

        public void OnUseItem(InputAction.CallbackContext context)
        {
            if (!context.performed || !canUse)
            {
                return;
            }
            if (playerInventory.EquippedItem is IUsableItem)
            {
                StartCoroutine(UseItem());
            }
        }

        IEnumerator UseItem()
        {
            canUse = false;
            IUsableItem item = (IUsableItem)playerInventory.EquippedItem;
            item.Use(gameObject);
            UsableItem usableItem = (UsableItem)playerInventory.EquippedItem;
            yield return new WaitForSeconds(usableItem.Speed);
            canUse = true;
            yield return new WaitForEndOfFrame();
        }

        public void UpdatePosition(InputAction.CallbackContext context)
        {
            //330 is center of player
            var interactorPosition = context.ReadValue<Vector2>();
            float xPos = interactorPosition.x;
            float yPos = interactorPosition.y;

            if (yPos > xPos)
            {
                //Is either up or left
                if (yPos < (xPos * -1) + 720)
                {
                    ClickFacing = Facing.Left;
                }
                else
                {
                    ClickFacing = Facing.Up;
                }

            }
            else
            {
                //Is either right or down
                if (yPos < (xPos * -1) + 720)
                {
                    ClickFacing = Facing.Down;
                }
                else
                {
                    ClickFacing = Facing.Right;
                }

            }


        }

        #endregion

        #region Misc

        #endregion
    }
}
