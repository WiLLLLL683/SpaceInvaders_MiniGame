﻿using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Enemy : MonoBehaviour, IDamageable, IKillable
    {
        [Header("Components")]
        [SerializeField] private ColliderUI colliderUI;
        [SerializeField] private Transform gunPoint;

        public event Action<IKillable> OnKilled;

        private IAiComponent ai;
        private IMovementComponent movement;
        private IAttackComponent attack;
        private IHealthComponent health;
        public EnemyConfig config;

        public void Init(EnemyConfig config, BulletFactory bulletFactory)
        {
            this.config = config;

            ai = new BasicAI(this, colliderUI, config.AI);
            movement = new BasicMovement(transform, config.Movement);
            attack = new AttackWithTimer(bulletFactory, gunPoint, config.Attack);
            health = new BasicHealth(config.Health.MaxHealth);

            ai.OnAttack += attack.Attack;
            ai.OnMove += movement.Move;
            health.OnDeath += Kill;
            colliderUI.OnCollisionEnter += DealDamage;

            ai.Enable();
        }

        private void OnDestroy()
        {
            ai.Disable();

            ai.OnAttack -= attack.Attack;
            ai.OnMove -= movement.Move;
            health.OnDeath -= Kill;
            colliderUI.OnCollisionEnter -= DealDamage;
        }

        public void TakeDamage(int damage) => health.TakeDamage(damage);

        public void Kill()
        {
            OnKilled?.Invoke(this);
            Destroy(gameObject);
        }

        private void DealDamage(ColliderUI collider)
        {
            if (collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(config.Attack.Damage);
            }
        }
    }
}