using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class StepMovement : IMovementComponent
    {
        private readonly Transform transform;
        private readonly MovementConfig config;
        private readonly RigidBodyUI rigidBodyUI;

        private Vector2 targetPosition;

        public StepMovement(Transform transform, MovementConfig config, RigidBodyUI rigidBodyUI = null)
        {
            this.transform = transform;
            this.config = config;
            this.rigidBodyUI = rigidBodyUI;
            targetPosition = transform.position;
        }

        public void Move(Vector2 direction)
        {
            Vector2 deltaPosition = direction * config.Speed;
            deltaPosition = Vector2.ClampMagnitude(deltaPosition, config.MaxDeltaPosition);
            targetPosition += deltaPosition;

            if (rigidBodyUI != null)
                rigidBodyUI.Move(targetPosition);
            else
                transform.position = targetPosition;
        }
    }
}