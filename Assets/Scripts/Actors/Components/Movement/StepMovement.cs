using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class StepMovement : IMovementComponent
    {
        private readonly Transform transform;
        private readonly MovementConfig config;

        public StepMovement(Transform transform, MovementConfig config)
        {
            this.transform = transform;
            this.config = config;
        }

        public void Move(Vector2 direction)
        {
            Vector2 deltaPosition = direction * config.Speed;
            deltaPosition = Vector2.ClampMagnitude(deltaPosition, config.MaxDeltaPosition);
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            transform.position = targetPosition;
        }
    }
}