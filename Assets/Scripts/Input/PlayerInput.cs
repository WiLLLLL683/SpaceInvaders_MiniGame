using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersMiniGame
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnMoveInput;

        private InputActions actions;

        private void Awake()
        {
            actions = new();
        }

        private void Update()
        {
            if (actions.MiniGame.Movement.IsPressed())
            {
                Vector2 direction = actions.MiniGame.Movement.ReadValue<Vector2>();
                OnMoveInput?.Invoke(direction);
            }
        }

        public void Enable() => actions.Enable();
        public void Disable() => actions.Disable();
    }
}