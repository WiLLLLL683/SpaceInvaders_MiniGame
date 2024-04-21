using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class StepEnemy : EnemyBase
    {
        [Header("Components")]
        [SerializeField] private ColliderUI colliderUI;
        [SerializeField] private Transform gunPoint;

        public override event Action<IKillable> OnKilled;

        private IAiComponent ai;
        private IMovementComponent movement;
        private IAttackComponent attack;
        private IHealthComponent health;
        private EnemyConfig config;

        public override void Init(EnemyConfig config, EnemiesData data, BulletFactory bulletFactory)
        {
            this.config = config;

            ai = new BasicAI(data, this, colliderUI, config.AI);
            movement = new StepMovement(transform, config.Movement);
            attack = new AttackWithCoolDown(bulletFactory, gunPoint, config.Attack);
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

        public override void TakeDamage(int damage) => health.TakeDamage(damage);

        public override void Kill()
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