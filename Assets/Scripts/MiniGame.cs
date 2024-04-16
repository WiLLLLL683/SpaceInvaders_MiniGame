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

        public void Launch()
        {
            //Initialize
            playerFactory = new(prefabConfig.PlayerPrefab, gameScreen.PlayerSpawnPoint, playerInput, playerConfig);

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