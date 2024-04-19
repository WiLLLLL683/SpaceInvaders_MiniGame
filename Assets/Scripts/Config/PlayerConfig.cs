using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "SpaceInvaders/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public MovementConfig MovementConfig;
        public AttackConfig AttackConfig;
    }
}