using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;
using ExtensionMethods;

namespace SpaceInvadersMiniGame
{
    public class BasicAI : IAiComponent
    {
        public event Action OnAttack;
        public event Action<Vector2> OnMove; //Vector2 - direction

        private readonly EnemiesData data;
        private readonly MonoBehaviour owner;
        private readonly ColliderUI collider;
        private readonly AIConfig config;

        private bool isEnabled;
        private float moveTimer;
        private float attackTimer;

        public BasicAI(EnemiesData data, MonoBehaviour owner, ColliderUI collider, AIConfig config)
        {
            this.data = data;
            this.owner = owner;
            this.collider = collider;
            this.config = config;
        }

        public void Enable()
        {
            isEnabled = true;
            moveTimer = config.MoveDelay;
            attackTimer = config.AttackDelay;
            owner.StartCoroutine(AIBehavior());

            collider.OnCollisionEnter += InvertMoveDirection;
        }

        public void Disable()
        {
            collider.OnCollisionEnter -= InvertMoveDirection;

            isEnabled = false;
            owner.StopCoroutine(AIBehavior());
        }

        private IEnumerator AIBehavior()
        {
            while (isEnabled)
            {
                TryMove();
                TryAttack();
                yield return null;
            }
        }

        private void TryMove()
        {
            moveTimer -= Time.deltaTime;

            if (moveTimer <= 0)
            {
                moveTimer = config.MoveDelay;
                OnMove?.Invoke(data.MoveDirection);
            }
        }

        private void TryAttack()
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                attackTimer = config.AttackDelay;
                OnMove?.Invoke(Vector2.down);
                OnAttack?.Invoke();
            }
        }

        private void InvertMoveDirection(ColliderUI collider)
        {
            if (!config.BoundLayers.IsInLayerMask(collider.gameObject.layer))
                return;

            if (Time.time - data.LastChangeTime <= config.MoveInversionDelay)
                return;

            data.MoveDirection *= -1;
            data.LastChangeTime = Time.time;
        }
    }
}