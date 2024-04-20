using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour, IDamageable
    {
        [Header("Components")]
        [SerializeField] private RigidBodyUI rigidBodyUI;
        [SerializeField] private Transform gunPoint;

        private IMovementComponent movemet;
        private IAttackComponent attack;
        private IHealthComponent health;

        private PlayerInput input;

        public void Init(PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.input = input;

            movemet = new RigidBodyMovement(transform, rigidBodyUI, config.Movement);
            attack = new AttackWithTimer(bulletFactory, gunPoint, config.Attack);
            health = new BasicHealth(config.Health.MaxHealth);

            input.OnMoveInput += movemet.Move;
            input.OnAttackInput += attack.Attack;
            health.OnDeath += Die;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= movemet.Move;
            input.OnAttackInput -= attack.Attack;
            health.OnDeath -= Die;
        }

        private void Update()
        {
            attack.Update();
        }

        public void TakeDamage(int damage) => health.TakeDamage(damage);
        private void Die() => Destroy(gameObject);
    }
}