using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class GameScreen : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text levelName;
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

        private MiniGame miniGame;

        public void Init(MiniGame miniGame)
        {
            this.miniGame = miniGame;

            miniGame.OnEnable += Show;
            miniGame.OnDisable += Hide;
            miniGame.OnLevelStarted += SetLevelName;
        }

        private void OnDestroy()
        {
            miniGame.OnEnable -= Show;
            miniGame.OnDisable -= Hide;
            miniGame.OnLevelStarted -= SetLevelName;
        }

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }

        public void SetLevelName(LevelConfig level)
        {
            levelName.text = level.LevelName;
        }
    }
}