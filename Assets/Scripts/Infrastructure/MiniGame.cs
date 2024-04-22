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
        [SerializeField] private EnemyAI enemyAI;
        [Header("Config")]
        [SerializeField] private MiniGameConfig gameConfig;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private EnemyAIConfig enemyAIConfig;
        [SerializeField] private List<LevelConfig> levels = new();

        public event Action OnEnable;
        public event Action OnDisable;

        private StateMachine stateMachine;
        private Container container;

        public void Enable()
        {
            container = new()
            {
                GameScreen = gameScreen,
                Input = playerInput,
                EnemyAI = enemyAI,
                GameConfig = gameConfig,
                PlayerConfig = playerConfig,
                EnemyAIConfig = enemyAIConfig,
                LevelsConfig = levels
            };

            stateMachine = new();
            stateMachine.AddState(new InitState(this, stateMachine, container));
            stateMachine.AddState(new StartGameState(this, stateMachine, container));
            stateMachine.AddState(new GamePlayState(this, stateMachine, container));
            stateMachine.AddState(new LevelClearedState(this, stateMachine, container));
            stateMachine.AddState(new LoseState(this, stateMachine, container));
            stateMachine.AddState(new WinState(this, stateMachine, container));

            stateMachine.EnterState<InitState>();
            OnEnable?.Invoke();
        }

        public void Disable()
        {
            stateMachine.ExitCurrentState();
            OnDisable?.Invoke();
        }
    }
}