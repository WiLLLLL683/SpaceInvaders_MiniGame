using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private ColliderUI colliderUI;

        private PlayerInput input;
        private PlayerConfig config;

        public void Init(PlayerInput input, PlayerConfig config)
        {
            this.input = input;
            this.config = config;

            input.OnMoveInput += Move;
            colliderUI.OnCollisionEnter += TeleportOutOfCollision;
            colliderUI.OnCollisionStay += TeleportOutOfCollision;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
            colliderUI.OnCollisionEnter -= TeleportOutOfCollision;
            colliderUI.OnCollisionStay -= TeleportOutOfCollision;
        }

        private void Move(float horizontalAxis)
        {
            float deltaX = horizontalAxis * config.MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(deltaX, 0f, 0f);
        }

        private void TeleportOutOfCollision(ColliderUI collider)
        {
            Rect rect1 = colliderUI.Rect;
            Rect rect2 = collider.Rect;

            float xDelta = 0;
            if (colliderUI.xMin > collider.Center.x)
            {
                xDelta = collider.xMax - colliderUI.xMin;
            }
            else
            {
                xDelta = collider.xMin - colliderUI.xMax;
            }

            transform.position += new Vector3(xDelta, 0);
        }
    }
}