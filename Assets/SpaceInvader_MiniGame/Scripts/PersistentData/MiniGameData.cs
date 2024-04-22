using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class MiniGameData
    {
        public int CurrentLevelIndex;

        public void Reset()
        {
            CurrentLevelIndex = 0;
        }
    }
}