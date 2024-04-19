using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class BulletFactory
    {
        private readonly Bullet prefab;
        private readonly Transform parent;

        public BulletFactory(Bullet prefab, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
        }

        public Bullet Create(Vector2 position, Vector2 direction, float speed, int damage)
        {
            Bullet bullet = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, parent);
            bullet.Init(direction, speed, damage);
            return bullet;
        }
    }
}