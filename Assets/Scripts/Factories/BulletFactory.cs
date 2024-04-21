using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class BulletFactory : KillableFactoryBase<Bullet>
    {
        public BulletFactory(Transform parent)
        {
            this.parent = parent;
        }

        public Bullet Create(AttackConfig config, Vector2 startPosition)
        {
            Bullet bullet = UnityEngine.Object.Instantiate(config.BulletPrefab, startPosition, Quaternion.identity, parent);
            bullet.Init(config.Direction, config.BulletSpeed, config.BulletMaxDeltaPosition, config.Damage);
            Register(bullet);
            return bullet;
        }
    }
}