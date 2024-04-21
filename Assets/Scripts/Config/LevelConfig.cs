using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Level", menuName = "SpaceInvaders/Level")]
    public class LevelConfig : ScriptableObject
    {
        public string LevelName;
        public List<EnemyConfig> Enemies = new();
    }
}