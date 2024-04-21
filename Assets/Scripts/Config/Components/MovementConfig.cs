using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class MovementConfig
    {
        [Min(0f)] public Vector2 Speed;
        [Min(0f)] public float MaxDeltaPosition;
    }
}