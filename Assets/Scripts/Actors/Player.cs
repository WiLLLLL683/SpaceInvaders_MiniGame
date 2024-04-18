using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private RigidBodyUI rigidBodyUI;

        private PlayerInput input;
        private PlayerConfig config;

        public void Init(PlayerInput input, PlayerConfig config)
        {
            this.input = input;
            this.config = config;

            rigidBodyUI.Init(config.CollisionThrowBack, config.SmoothTime, config.MaxSpeed);

            input.OnMoveInput += Move;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
        }

        private void Move(Vector2 direction)
        {
            direction.y = 0;
            Vector2 deltaPosition = direction * config.MaxSpeed * Time.deltaTime;
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            rigidBodyUI.Move(targetPosition);
        }
    }
}