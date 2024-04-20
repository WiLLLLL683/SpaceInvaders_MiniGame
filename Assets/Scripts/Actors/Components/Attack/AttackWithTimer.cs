using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class AttackWithTimer : IAttackComponent
    {
        private readonly BulletFactory bulletFactory;
        private readonly Transform gunPoint;
        private readonly AttackConfig config;

        private float attackTimer;

        public AttackWithTimer(BulletFactory bulletFactory, Transform gunPoint, AttackConfig config)
        {
            this.bulletFactory = bulletFactory;
            this.gunPoint = gunPoint;
            this.config = config;
        }

        public void Attack()
        {
            if (attackTimer > 0)
                return;

            bulletFactory.Create(gunPoint.position, config.Direction, config.BulletSpeed, config.Damage);
            attackTimer = config.Delay;
        }

        public void Update()
        {
            attackTimer -= Time.deltaTime;
            attackTimer = MathF.Max(0, attackTimer);
        }
    }
}