using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersMiniGame
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<float> OnMoveInput;

        private InputActions actions;

        private void Awake()
        {
            actions = new();
        }

        private void Update()
        {
            if (actions.MiniGame.HorizontalMovement.IsPressed())
            {
                float horizontalAxis = actions.MiniGame.HorizontalMovement.ReadValue<float>();
                OnMoveInput?.Invoke(horizontalAxis);
            }
        }

        public void Enable() => actions.Enable();
        public void Disable() => actions.Disable();
    }
}