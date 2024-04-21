using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class MovementConfig
    {
        [Min(0f)] public Vector2 Speed = new(50,50);
        [Min(0f)] public float MaxDeltaPosition = 100;
        [Min(0f)] public float Delay;
    }
}