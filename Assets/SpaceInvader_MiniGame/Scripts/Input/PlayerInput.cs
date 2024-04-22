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

        public InputActions Actions { get; private set; }

        public void Init()
        {
            Actions = new();
        }

        private void Update()
        {
            if (Actions.MiniGame.Movement.IsPressed())
            {
                MoveInput();
            }
        }

        public void Enable()
        {
            Actions.Enable();

            Actions.MiniGame.Attack.performed += AttackInput;
        }

        public void Disable()
        {
            Actions.Disable();

            Actions.MiniGame.Attack.performed -= AttackInput;
        }

        private void MoveInput()
        {
            Vector2 direction = Actions.MiniGame.Movement.ReadValue<Vector2>();
            OnMoveInput?.Invoke(direction);
        }

        private void AttackInput(InputAction.CallbackContext obj)
        {
            OnAttackInput?.Invoke();
        }
    }
}