using CustomStateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class InitState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Container cont;

        public InitState(MiniGame owner, StateMachine stateMachine, Container cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //Create persistent data
            cont.GameData = new();

            //Create factories
            cont.ExplosionFactory = new(cont.GameScreen.ExplosionParent, cont.GameConfig.ExplosionPrefab);
            cont.BulletFactory = new(cont.GameScreen.BulletParent, cont.ExplosionFactory);
            cont.PlayerFactory = new(cont.GameScreen.PlayerSpawnPoint, cont.GameScreen.PlayerParent, cont.Input, cont.BulletFactory, cont.PlayerConfig);
            cont.EnemyFactory = new(cont.EnemyAI, cont.GameScreen.EnemySpawnPoints, cont.GameScreen.EnemiesParent, cont.BulletFactory);

            //Init prefab components 
            cont.Input.Init();
            cont.GameScreen.Init(cont.Input);
            cont.EnemyAI.Init(cont.EnemyAIConfig);

            //=>
            stateMachine.EnterState<StartGameState>();
        }

        public void OnExit()
        {

        }
    }
}