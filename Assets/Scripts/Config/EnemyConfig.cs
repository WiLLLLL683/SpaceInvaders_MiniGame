﻿using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Enemy", menuName = "SpaceInvaders/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        public Enemy Prefab;
        public HealthConfig Health;
        public MovementConfig Movement;
        public AttackConfig Attack;
        public AIConfig AI;
    }
}