using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [Header("Components")]
        [SerializeField] private ColliderUI colliderUI;
        [SerializeField] private Transform gunPoint;

        private IAiComponent ai;
        private IMovementComponent movement;
        private IAttackComponent attack;
        private IHealthComponent health;

        public void Init(EnemyConfig config, BulletFactory bulletFactory)
        {
            ai = new BasicAI(this, colliderUI, config.AI);
            movement = new BasicMovement(transform, config.Movement);
            attack = new AttackWithTimer(bulletFactory, gunPoint, config.Attack);
            health = new BasicHealth(config.Health.MaxHealth);

            ai.OnAttack += attack.Attack;
            ai.OnMove += movement.Move;
            health.OnDeath += Die;

            ai.Enable();
        }

        private void OnDestroy()
        {
            ai.Disable();

            ai.OnAttack -= attack.Attack;
            ai.OnMove -= movement.Move;
            health.OnDeath -= Die;
        }

        public void TakeDamage(int damage) => health.TakeDamage(damage);
        private void Die() => Destroy(gameObject);
    }
}