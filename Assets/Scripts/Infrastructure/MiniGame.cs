using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomStateMachine;

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
        public event Action<LevelConfig> OnLevelStarted;

        private StateMachine stateMachine;
        private Dependencies container;

        public void Enable()
        {
            container = new()
            {
                GameScreen = gameScreen,
                Input = playerInput,
                PlayerConfig = playerConfig,
                LevelsConfig = levels
            };
            stateMachine = new();
            stateMachine.AddState(new InitState(this, container));

            stateMachine.EnterState<InitState>();

            //TODO переместить в стейты
            StartNewGame();
            OnEnable?.Invoke();
        }

        public void Disable()
        {
            CleanUp();
            playerInput.Disable();
            OnDisable?.Invoke();
        }

        public void StartNewGame()
        {
            container.GameData.Reset();
            StartLevel(0);
        }
        public void StartLevel(int index)
        {
            CleanUp();
            playerInput.Enable();
            container.PlayerFactory.Create();
            container.EnemyFactory.CreateLevelEnemies(levels[index]);
            OnLevelStarted?.Invoke(levels[index]);

            container.PlayerFactory.OnClear += Lose;
            container.EnemyFactory.OnClear += LevelCleared;
        }

        private void CleanUp()
        {
            container.PlayerFactory.OnClear -= Lose;
            container.EnemyFactory.OnClear -= LevelCleared;

            container.EnemiesData.Reset();
            container.EnemyFactory.Clear();
            container.PlayerFactory.Clear();
            container.BulletFactory.Clear();
        }

        //Game logic
        private void Win() => Disable();
        private void Lose() => StartNewGame();
        private void LevelCleared()
        {
            container.GameData.CurrentLevelIndex++;
            bool allLevelsCleared = container.GameData.CurrentLevelIndex >= levels.Count;

            if (allLevelsCleared)
            {
                Win();
            }
            else
            {
                StartLevel(container.GameData.CurrentLevelIndex);
            }
        }
    }
}