using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class AttackWithCoolDown : IAttackComponent
    {
        private readonly BulletFactory bulletFactory;
        private readonly Transform gunPoint;
        private readonly AttackConfig config;

        private float attackTimer;

        public AttackWithCoolDown(BulletFactory bulletFactory, Transform gunPoint, AttackConfig config)
        {
            this.bulletFactory = bulletFactory;
            this.gunPoint = gunPoint;
            this.config = config;
        }

        public void Attack()
        {
            if (attackTimer > 0)
                return;

            bulletFactory.Create(config, gunPoint.position);
            attackTimer = config.CoolDown;
        }

        public void Update()
        {
            attackTimer -= Time.deltaTime;
            attackTimer = MathF.Max(0, attackTimer);
        }
    }
}