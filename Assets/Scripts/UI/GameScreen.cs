using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;
        [SerializeField] private Transform bulletParent;

        public Transform PlayerSpawnPoint => playerSpawnPoint;
        public List<Transform> EnemySpawnPoints => enemySpawnPoints;
        public Transform BulletParent => bulletParent;

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}