using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class BasicAI : IAI
    {
        public event Action OnAttack;
        public event Action<Vector2> OnMove; //Vector2 - direction

        private readonly MonoBehaviour owner;
        private readonly ColliderUI collider;
        private readonly AIConfig config;

        private bool isEnabled;
        private float moveTimer;
        private float attackTimer;
        //private Vector2 startPosition;
        private Vector2 moveDirection;
        private int movesDelta;

        public BasicAI(MonoBehaviour owner, ColliderUI collider, AIConfig config)
        {
            this.owner = owner;
            this.collider = collider;
            this.config = config;
            //this.startPosition = collider.Center;
            this.moveDirection = Vector2.left;
        }

        public void Enable()
        {
            isEnabled = true;
            moveTimer = config.MoveDelay;
            attackTimer = config.AttackDelay;

            owner.StartCoroutine(AIBehavior());
        }

        public void Disable()
        {
            isEnabled = false;
            owner.StopCoroutine(AIBehavior());
        }

        private IEnumerator AIBehavior()
        {
            while (isEnabled)
            {
                TryMove();
                //TryAttack();
                yield return null;
            }
        }

        private void CheckMoveDirection()
        {
            int movesCount = Mathf.Abs(movesDelta);
            Debug.Log($"movesDelta = {movesDelta}, movesCount = {movesCount}, direction = {moveDirection}");

            if (movesCount >= config.MovesInOneDirection)
            {
                moveDirection *= -1; //TODO определять направление через положение
            }
        }

        private void TryMove()
        {
            moveTimer -= Time.deltaTime;

            if (moveTimer <= 0)
            {
                CheckMoveDirection();

                movesDelta += Mathf.RoundToInt(Mathf.Clamp(moveDirection.x, -1, 1));
                moveTimer = config.MoveDelay;
                OnMove?.Invoke(moveDirection);
            }
        }

        private void TryAttack()
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                attackTimer = config.AttackDelay;
                OnAttack?.Invoke();
                OnMove?.Invoke(Vector2.down);
            }
        }
    }
}