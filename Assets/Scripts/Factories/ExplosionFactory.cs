using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class ExplosionFactory : KillableFactoryBase<Explosion>
    {
        private readonly Explosion prefab;

        public ExplosionFactory(Transform parent, Explosion prefab)
        {
            this.parent = parent;
            this.prefab = prefab;
        }

        public Explosion Create(Vector2 position)
        {
            Explosion explosion = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, parent);
            Register(explosion);
            return explosion;
        }
    }
}