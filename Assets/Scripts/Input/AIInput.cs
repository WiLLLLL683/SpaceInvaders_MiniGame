using CustomUIPhysics;
using ExtensionMethods;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class AIInput : MonoBehaviour
    {
        private AIConfig config;

        private Dictionary<EnemyBase, ColliderUI> enemies = new();
        private float moveTimer;
        private float attackTimer;
        private Vector2 moveDirection = Vector2.left;
        private float lastChangeTime;
        private bool isEnabled;

        public void Init(AIConfig config)
        {
            this.config = config;
        }

        public void Update()
        {
            if (!isEnabled)
                return;

            moveTimer -= Time.deltaTime;
            attackTimer -= Time.deltaTime;

            TryMove();
            TryAttack();
        }

        public void Enable()
        {
            isEnabled = true;
            moveTimer = config.MoveDelay;
            attackTimer = config.AttackDelay;
        }

        public void Disable()
        {
            isEnabled = false;
            enemies.Clear();
            moveDirection = Vector2.left;
        }

        public void Register(EnemyBase enemy)
        {
            if (!enemy.TryGetComponent(out ColliderUI collider))
                return;

            enemies.Add(enemy, collider);
            collider.OnCollisionEnter += InvertMoveDirection;
            enemy.OnKilled += DeRegister;
            Debug.Log("Register");
        }

        private void DeRegister(IKillable killable)
        {
            killable.OnKilled -= DeRegister;

            if (killable is not EnemyBase enemy)
                return;

            if (!enemies.ContainsKey(enemy))
                return;

            enemies[enemy].OnCollisionEnter -= InvertMoveDirection;
            enemies.Remove(enemy);
            Debug.Log("DeRegister");
        }

        private void TryMove()
        {
            if (moveTimer > 0)
                return;

            moveTimer = config.MoveDelay;

            foreach (var enemy in enemies.Keys)
            {
                enemy.Move(moveDirection);
            }
        }

        private void TryAttack()
        {
            if (attackTimer > 0)
                return;

            attackTimer = config.AttackDelay;
            foreach (var enemy in enemies.Keys)
            {
                enemy.Move(Vector2.down);
            }

            EnemyBase attackingEnemy = GetAttackingEnemy();
            attackingEnemy?.Attack();
        }

        private EnemyBase GetAttackingEnemy()
        {
            List<EnemyBase> ableToAttack = new();

            foreach (var enemy in enemies.Keys)
            {
                if (enemy.IsAbleToAttack)
                {
                    ableToAttack.Add(enemy);
                }
            }

            Debug.Log($"ableToAttackCount:{ableToAttack.Count}");

            if (ableToAttack.Count == 0)
                return null;

            int random = UnityEngine.Random.Range(0, ableToAttack.Count);
            return ableToAttack[random];
        }

        private void InvertMoveDirection(ColliderUI collider)
        {
            if (!config.BoundLayers.IsInLayerMask(collider.gameObject.layer))
                return;

            if (Time.time - lastChangeTime <= config.MoveInversionDelay)
                return;

            moveDirection *= -1;
            lastChangeTime = Time.time;
        }
    }
}