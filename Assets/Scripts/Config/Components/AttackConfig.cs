using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class AttackConfig
    {
        public Bullet BulletPrefab;
        [Min(0f)] public float BulletSpeed = 1000;
        [Min(0f)] public float BulletMaxDeltaPosition = 100;
        [Min(0f)] public float CoolDown;
        [Min(0f)] public int Damage = 1;
        public Vector2 Direction;
    }
}