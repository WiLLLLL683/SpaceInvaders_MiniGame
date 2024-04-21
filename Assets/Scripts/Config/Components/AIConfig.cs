using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class AIConfig
    {
        [Min(0f)] public float AttackDelay;
        [Min(0f)] public float MoveDelay;
        [Min(0f)] public float MoveInversionDelay;
        public LayerMask BoundLayers;
    }
}