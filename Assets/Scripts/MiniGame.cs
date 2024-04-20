using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class MiniGame : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameScreen gameScreen;
        [SerializeField] private PlayerInput playerInput;
        [Header("Config")]
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private List<LevelConfig> levels = new();

        public event Action OnEnable;
        public event Action OnDisable;

        private PlayerFactory playerFactory;
        private BulletFactory bulletFactory;
        private EnemyFactory enemyFactory;
        private MiniGameState state;

        public void Enable()
        {
            bulletFactory = new(gameScreen.BulletParent);
            playerFactory = new(gameScreen.PlayerSpawnPoint, playerInput, bulletFactory, playerConfig);
            enemyFactory = new(gameScreen.EnemySpawnPoints, bulletFactory);
            state = new();

            StartNewGame();
            OnEnable?.Invoke();
        }

        public void Disable()
        {
            CleanUp();
            playerInput.Disable();
            gameScreen.Hide();
            OnDisable?.Invoke();
        }

        public void StartNewGame() => StartLevel(0);
        public void StartLevel(int index)
        {
            CleanUp();
            playerInput.Enable();
            playerFactory.Create();
            enemyFactory.CreateLevelEnemies(levels[index]);
            gameScreen.Show();

            playerFactory.OnClear += Lose;
            enemyFactory.OnClear += LevelCleared;
        }

        private void CleanUp()
        {
            playerFactory.OnClear -= Lose;
            enemyFactory.OnClear -= LevelCleared;

            enemyFactory.Clear();
            playerFactory.Clear();
            bulletFactory.Clear();
        }

        //Game logic
        private void Win() => Disable();
        private void Lose() => StartNewGame();
        private void LevelCleared()
        {
            state.CurrentLevelIndex++;
            bool allLevelsCleared = state.CurrentLevelIndex >= levels.Count;

            if (allLevelsCleared)
            {
                Win();
            }
            else
            {
                StartLevel(state.CurrentLevelIndex);
            }
        }
    }
}