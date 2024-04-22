using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public abstract class EnemyBase : MonoBehaviour, IDamageable, IKillable
    {
        public abstract event Action<IKillable> OnKilled;

        public abstract bool IsAbleToAttack { get; }

        public abstract void Move(Vector2 direction);
        public abstract void Attack();
        public abstract void Kill();
        public abstract void Init(EnemyConfig config, BulletFactory bulletFactory);
        public abstract void TakeDamage(int damage);
    }
}