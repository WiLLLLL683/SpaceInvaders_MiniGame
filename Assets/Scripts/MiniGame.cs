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
        [SerializeField] private PrefabConfig prefabConfig;
        [SerializeField] private PlayerConfig playerConfig;

        private PlayerFactory playerFactory;
        private BulletFactory bulletFactory;

        public void Launch()
        {
            //Initialize
            bulletFactory = new(prefabConfig.BulletPrefab, gameScreen.BulletParent);
            playerFactory = new(prefabConfig.PlayerPrefab, gameScreen.PlayerSpawnPoint, playerInput, bulletFactory, playerConfig);

            StartGame();
        }

        private void OpenMainMenu()
        {
            playerInput.Disable();

            gameScreen.Hide();
            mainMenuScreen.Show();
        }

        private void StartGame()
        {
            playerInput.Enable();
            playerFactory.Create();

            mainMenuScreen.Hide();
            gameScreen.Show();
        }
    }
}