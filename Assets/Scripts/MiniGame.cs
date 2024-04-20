using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class MiniGame : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private MainMenuScreen mainMenuScreen;
        [SerializeField] private GameScreen gameScreen;
        [SerializeField] private PlayerInput playerInput;
        [Header("Config")]
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private List<LevelConfig> levels = new();
        [SerializeField] private EnemyConfig defaultEnemy;
        //TODO LevelConfig

        private PlayerFactory playerFactory;
        private BulletFactory bulletFactory;
        private EnemyFactory enemyFactory;

        //game state
        private int currentLevelIndex;

        public void Enable()
        {
            //Initialize
            bulletFactory = new(gameScreen.BulletParent);
            playerFactory = new(gameScreen.PlayerSpawnPoint, playerInput, bulletFactory, playerConfig);
            enemyFactory = new(gameScreen.EnemySpawnPoints, bulletFactory, defaultEnemy);

            StartLevel(0);
        }

        public void Disable()
        {
            //TODO
        }

        public void OpenMainMenu()
        {
            CleanUp();

            playerInput.Disable();

            gameScreen.Hide();
            mainMenuScreen.Show();
        }

        public void StartLevel(int index)
        {
            CleanUp();

            playerInput.Enable();
            playerFactory.Create();
            enemyFactory.CreateLevelEnemies(levels[index]);

            mainMenuScreen.Hide();
            gameScreen.Show();
        }

        public void StartNextLevel()
        {
            currentLevelIndex++;

            if (currentLevelIndex < levels.Count)
            {
                StartLevel(currentLevelIndex);
            }
            else
            {
                OpenMainMenu();
            }
        }

        private void CleanUp()
        {
            enemyFactory.Clear();
            playerFactory.Clear();
            bulletFactory.Clear();
        }
    }
}