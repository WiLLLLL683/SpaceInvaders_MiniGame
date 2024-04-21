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

        public StepMovement(Transform transform, MovementConfig config, RigidBodyUI rigidBodyUI = null)
        {
            this.transform = transform;
            this.config = config;
            this.rigidBodyUI = rigidBodyUI;
        }

        public void Move(Vector2 direction)
        {
            Vector2 deltaPosition = direction * config.Speed;
            deltaPosition = Vector2.ClampMagnitude(deltaPosition, config.MaxDeltaPosition);
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;

            if (rigidBodyUI != null)
                rigidBodyUI.Move(targetPosition);
            else
                transform.position = targetPosition;
        }
    }
}