using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceInvadersMiniGame
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnMoveInput;
        public event Action OnAttackInput;

        private InputActions actions;

        private void Awake()
        {
            actions = new();
        }

        private void Update()
        {
            if (actions.MiniGame.Movement.IsPressed())
            {
                MoveInput();
            }
        }

        public void Enable()
        {
            actions.Enable();

            actions.MiniGame.Attack.performed += AttackInput;
        }

        public void Disable()
        {
            actions.Disable();

            actions.MiniGame.Attack.performed -= AttackInput;
        }

        private void MoveInput()
        {
            Vector2 direction = actions.MiniGame.Movement.ReadValue<Vector2>();
            OnMoveInput?.Invoke(direction);
        }

        private void AttackInput(InputAction.CallbackContext obj)
        {
            OnAttackInput?.Invoke();
        }
    }
}