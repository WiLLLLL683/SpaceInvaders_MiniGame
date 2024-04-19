using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class RigidBodyMovement : IMovementComponent
    {
        private readonly Transform transform;
        private readonly RigidBodyUI rigidBodyUI;
        private readonly MovementConfig config;

        public RigidBodyMovement(Transform transform, RigidBodyUI rigidBodyUI, MovementConfig config)
        {
            this.transform = transform;
            this.rigidBodyUI = rigidBodyUI;
            this.config = config;

            rigidBodyUI.Init(config.CollisionThrowBack, config.SmoothTime, config.MaxSpeed);
        }

        public void Move(Vector2 direction)
        {
            direction.y = 0;
            Vector2 deltaPosition = direction * config.MaxSpeed * Time.deltaTime;
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            rigidBodyUI.Move(targetPosition);
        }
    }
}