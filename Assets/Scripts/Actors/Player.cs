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

        private PlayerInput input;
        private BulletFactory bulletFactory;
        private PlayerConfig config;
        private float attackTimer;

        public void Init(PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.input = input;
            this.bulletFactory = bulletFactory;
            this.config = config;

            rigidBodyUI.Init(config.CollisionThrowBack, config.SmoothTime, config.MaxSpeed);

            input.OnMoveInput += Move;
            input.OnAttackInput += Attack;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= Move;
            input.OnAttackInput -= Attack;
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
            attackTimer = MathF.Max(0, attackTimer);
        }

        public void TakeDamage(int damage)
        {
            //TODO
            Debug.Log($"Player taken damage:{damage}");
        }

        private void Move(Vector2 direction)
        {
            direction.y = 0;
            Vector2 deltaPosition = direction * config.MaxSpeed * Time.deltaTime;
            Vector2 targetPosition = (Vector2)transform.position + deltaPosition;
            rigidBodyUI.Move(targetPosition);
        }

        private void Attack()
        {
            if (attackTimer > 0)
                return;

            bulletFactory.Create(gunPoint.position, config.AttackDirection, config.BulletSpeed, config.AttackDamage);
            attackTimer = config.AttackDelay;
        }
    }
}