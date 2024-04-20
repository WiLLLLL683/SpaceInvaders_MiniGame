using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PrefabConfig", menuName = "SpaceInvaders/PrefabConfig")]
    public class PrefabConfig : ScriptableObject
    {
        public Player PlayerPrefab;
        public Bullet BulletPrefab;
        public Enemy EnemyPrefab;
    }
}