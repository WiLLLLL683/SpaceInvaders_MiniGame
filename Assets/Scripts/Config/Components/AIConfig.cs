using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class AIConfig
    {
        [Min(0f)] public float MoveDelay;
        [Min(1)] public int MovesInOneDirection;
        [Min(0f)] public float AttackDelay;
    }
}