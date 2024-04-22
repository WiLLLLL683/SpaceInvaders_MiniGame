using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour, IDamageable, IKillable
    {
        [Header("Components")]
        [SerializeField] private RigidBodyUI rigidBodyUI;
        [SerializeField] private Transform gunPoint;

        public event Action<IKillable> OnKilled;

        private IMovementComponent movemet;
        private IAttackComponent attack;
        private IHealthComponent health;

        private PlayerInput input;

        public void Init(PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.input = input;

            movemet = new ContinuousMovement(transform, config.Movement, rigidBodyUI);
            attack = new AttackWithCoolDown(bulletFactory, gunPoint, config.Attack);
            health = new BasicHealth(config.Health.MaxHealth);

            input.OnMoveInput += movemet.Move;
            input.OnAttackInput += attack.Attack;
            health.OnDeath += Kill;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= movemet.Move;
            input.OnAttackInput -= attack.Attack;
            health.OnDeath -= Kill;
        }

        private void Update()
        {
            attack.Update();
        }

        public void TakeDamage(int damage) => health.TakeDamage(damage);

        public void Kill()
        {
            OnKilled?.Invoke(this);
            Destroy(gameObject);
        }
    }
}