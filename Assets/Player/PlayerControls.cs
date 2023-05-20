using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TwoDLife.Player
{
    public class PlayerControls : NetworkBehaviour
    {
        //Variables
        Vector2 move;
        public bool canMove = true;
        public float playerSpeed = 1f;
        //Properties
        Rigidbody2D playerRigid;
        BoxCollider2D playerCollider;

        void Start()
        {
            playerRigid = GetComponentInChildren<Rigidbody2D>();
            playerCollider = GetComponentInChildren<BoxCollider2D>();
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
        }

        #endregion

        #region Misc

        #endregion
    }
}
