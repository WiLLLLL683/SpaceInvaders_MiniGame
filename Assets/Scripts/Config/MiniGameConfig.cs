using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SpaceInvaders/GameConfig")]
    public class MiniGameConfig : ScriptableObject
    {
        public float DelayAfterSpawn;
    }
}