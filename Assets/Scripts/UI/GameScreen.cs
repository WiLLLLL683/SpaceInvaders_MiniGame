using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class GameScreen : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Canvas canvas;
        [Header("Parents")]
        [SerializeField] private Transform playerParent;
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private Transform bulletParent;
        [Header("Spawn points")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;

        public Transform PlayerParent => playerParent;
        public Transform EnemiesParent => enemiesParent;
        public Transform BulletParent => bulletParent;
        public Transform PlayerSpawnPoint => playerSpawnPoint;
        public List<Transform> EnemySpawnPoints => enemySpawnPoints;

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