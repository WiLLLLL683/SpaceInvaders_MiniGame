using UnityEngine;

namespace SpaceInvadersMiniGame
{
    [System.Serializable]
    public class EnemiesData
    {
        public Vector2 MoveDirection = Vector2.left;
        public float LastChangeTime;

        public void Reset()
        {
            LastChangeTime = Time.time;
            MoveDirection = Vector2.left;
        }
    }
}