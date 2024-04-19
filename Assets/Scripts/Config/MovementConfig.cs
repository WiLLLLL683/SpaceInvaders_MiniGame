using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class MovementConfig
    {
        [Min(0f)] public float MaxSpeed;
        [Min(0.01f)] public float SmoothTime;
        [Min(0.01f)] public float CollisionThrowBack;
    }
}