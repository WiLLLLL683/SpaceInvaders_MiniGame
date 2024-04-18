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

        private void Move(float horizontalAxis)
        {
            float deltaX = horizontalAxis * config.MaxSpeed * Time.deltaTime;
            var targetPosition = transform.position + new Vector3(deltaX, 0);
            rigidBodyUI.Move(targetPosition);
        }
    }
}