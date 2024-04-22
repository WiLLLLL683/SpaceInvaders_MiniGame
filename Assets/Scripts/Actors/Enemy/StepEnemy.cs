using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class StepEnemy : EnemyBase
    {
        [Header("Components")]
        [SerializeField] private ColliderUI colliderUI;
        [SerializeField] private ColliderUI frontColliderUI;
        [SerializeField] private Transform gunPoint;

        public override bool IsAbleToAttack => !frontColliderUI.HaveCollisions;
        public override event Action<IKillable> OnKilled;

        private IMovementComponent movement;
        private IAttackComponent attack;
        private IHealthComponent health;

        private EnemyConfig config;

        public override void Init(EnemyConfig config, BulletFactory bulletFactory)
        {
            this.config = config;

            movement = new StepMovement(transform, config.Movement);
            attack = new AttackWithCoolDown(bulletFactory, gunPoint, config.Attack);
            health = new BasicHealth(config.Health.MaxHealth);

            health.OnDeath += Kill;
            colliderUI.OnCollisionEnter += DealDamage;
        }

        private void OnDestroy()
        {
            health.OnDeath -= Kill;
            colliderUI.OnCollisionEnter -= DealDamage;
        }

        public override void Move(Vector2 direction) => movement.Move(direction);
        public override void Attack() => attack.Attack();
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