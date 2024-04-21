using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class SmoothMovement : IMovementComponent
    {
        private readonly Transform transform;
        private readonly RigidBodyUI rigidBodyUI;
        private readonly MovementConfig config;

        public SmoothMovement(Transform transform, RigidBodyUI rigidBodyUI, MovementConfig config)
        {
            this.transform = transform;
            this.rigidBodyUI = rigidBodyUI;
            this.config = config;
        }

        public void Move(Vector2 direction)
        {
            direction.y = 0;
            Vector2 deltaPosition = direction * config.Speed * Time.deltaTime;
            deltaPosition = Vector2.ClampMagnitude(deltaPosition, config.MaxDeltaPosition);
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            rigidBodyUI.Move(targetPosition);
        }
    }
}