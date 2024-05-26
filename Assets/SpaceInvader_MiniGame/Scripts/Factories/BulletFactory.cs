using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class BulletFactory : FactoryBase<Bullet>
    {
        private readonly ExplosionFactory explosionFactory;

        public BulletFactory(Transform parent, ExplosionFactory explosionFactory)
        {
            this.parent = parent;
            this.explosionFactory = explosionFactory;
        }

        public Bullet Create(AttackConfig config, Vector2 startPosition)
        {
            Bullet bullet = GameObject.Instantiate(config.BulletPrefab, startPosition, Quaternion.identity, parent);
            bullet.Init(config.Direction, config.BulletSpeed, config.BulletMaxDeltaPosition, config.Damage, explosionFactory);
            Register(bullet);
            return bullet;
        }
    }
}