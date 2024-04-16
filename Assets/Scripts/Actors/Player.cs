using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour
    {
        private PlayerInput input;
        private PlayerConfig config;

        public void Init(PlayerInput input, PlayerConfig config)
        {
            this.input = input;
            this.config = config;

            input.OnMoveInput += Move;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
        }

        private void Move(float horizontalAxis)
        {
            float deltaX = horizontalAxis * config.MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(deltaX, 0f, 0f);
        }
    }
}