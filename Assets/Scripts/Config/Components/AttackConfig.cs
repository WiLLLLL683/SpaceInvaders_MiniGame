﻿using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class AttackConfig
    {
        [Min(0f)] public float BulletSpeed;
        [Min(0f)] public float Delay;
        [Min(0f)] public int Damage;
        public Vector2 Direction;
    }
}