using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "SpaceInvaders/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Min(0f)] public float MaxSpeed;
        [Min(0.01f)] public float SmoothTime;
        [Min(0.01f)] public float CollisionThrowBack;
    }
}