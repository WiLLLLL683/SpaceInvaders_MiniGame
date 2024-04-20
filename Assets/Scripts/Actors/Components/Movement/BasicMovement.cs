using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class BasicMovement : IMovementComponent
    {
        private readonly Transform transform;
        private readonly MovementConfig config;

        public BasicMovement(Transform transform, MovementConfig config)
        {
            this.transform = transform;
            this.config = config;
        }

        public void Move(Vector2 direction)
        {
            Vector2 deltaPosition = direction * config.Speed * Time.deltaTime;
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            transform.position = targetPosition;
        }
    }
}