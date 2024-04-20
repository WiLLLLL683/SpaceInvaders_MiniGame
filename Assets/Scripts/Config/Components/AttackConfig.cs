using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class AttackConfig
    {
        [Min(0f)] public float BulletSpeed;
        [Min(0f)] public float AttackDelay;
        public Vector2 AttackDirection;
        [Min(0f)] public int AttackDamage;
    }
}