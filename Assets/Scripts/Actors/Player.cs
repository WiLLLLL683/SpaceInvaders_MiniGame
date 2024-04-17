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
        private Vector2 targetPosition;
        private Vector2 velocity;

        private void Awake()
        {
            targetPosition = transform.position;
        }

        public void Init(PlayerInput input, PlayerConfig config)
        {
            this.input = input;
            this.config = config;

            input.OnMoveInput += Move;
            colliderUI.OnCollisionEnter += MoveOutOfCollision;
            colliderUI.OnCollisionStay += MoveOutOfCollision;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
            colliderUI.OnCollisionEnter -= MoveOutOfCollision;
            colliderUI.OnCollisionStay -= MoveOutOfCollision;
        }

        private void Update()
        {
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, config.SmoothTime, config.MaxSpeed);
        }

        private void Move(float horizontalAxis)
        {
            if (colliderUI.HaveCollisions)
                return;

            float deltaX = horizontalAxis * config.MaxSpeed * Time.deltaTime;
            targetPosition = transform.position + new Vector3(deltaX, 0);
        }

        private void MoveOutOfCollision(ColliderUI collider)
        {
            float deltaX;
            if (colliderUI.Center.x > collider.Center.x)
            {
                deltaX = collider.xMax - colliderUI.xMin + config.CollisionThrowBack;
            }
            else
            {
                deltaX = collider.xMin - colliderUI.xMax - config.CollisionThrowBack;
            }

            float deltaY;
            if (colliderUI.Center.y > collider.Center.y)
            {
                deltaY = collider.yMax - colliderUI.yMin + config.CollisionThrowBack;
            }
            else
            {
                deltaY = collider.yMin - colliderUI.yMax - config.CollisionThrowBack;
            }

            if (deltaX > deltaY)
            {
                targetPosition = transform.position + new Vector3(deltaX, 0);
            }
            else
            {
                targetPosition = transform.position + new Vector3(0, deltaY);
            }
        }
    }
}