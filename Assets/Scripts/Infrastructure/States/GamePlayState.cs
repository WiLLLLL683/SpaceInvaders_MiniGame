using CustomStateMachine;
using System;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;

namespace SpaceInvadersMiniGame
{
    public class GamePlayState : IPayLoadedState<int>
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Dependencies cont;

        public GamePlayState(MiniGame owner, StateMachine stateMachine, Dependencies cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter(int levelIndex) => owner.StartCoroutine(OnEnterRoutine(levelIndex));
        private IEnumerator OnEnterRoutine(int levelIndex)
        {
            LevelConfig currentLevel = cont.LevelsConfig[levelIndex];

            //Create actors
            cont.PlayerFactory.Create();
            cont.EnemyFactory.CreateLevelEnemies(currentLevel);

            //Update UI
            cont.GameScreen.SetLevelName(currentLevel.LevelName);

            yield return new WaitForSeconds(cont.GameConfig.DelayAfterSpawn);

            //Enable input
            cont.Input.Enable();

            //=>
            cont.PlayerFactory.OnClear += stateMachine.EnterState<LoseState>;
            cont.EnemyFactory.OnClear += stateMachine.EnterState<LevelClearedState>;
        }

        public void OnExit()
        {
            cont.PlayerFactory.OnClear -= stateMachine.EnterState<LoseState>;
            cont.EnemyFactory.OnClear -= stateMachine.EnterState<LevelClearedState>;

            //Disable input
            cont.Input.Disable();

            //Reset per-level data
            cont.EnemiesData.Reset();

            //Clear actors
            cont.EnemyFactory.Clear();
            cont.PlayerFactory.Clear();
            cont.BulletFactory.Clear();
        }
    }
}