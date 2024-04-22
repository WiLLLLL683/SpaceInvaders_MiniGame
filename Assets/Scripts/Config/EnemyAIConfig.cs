using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "EnemyAIConfig", menuName = "SpaceInvaders/EnemyAIConfig")]
    public class EnemyAIConfig : ScriptableObject
    {
        [Min(0f)] public float AttackDelay;
        [Min(0f)] public float MoveDelay;
        [Min(0f)] public float MoveInversionDelay;
        public LayerMask MoveInversionLayers;
    }
}