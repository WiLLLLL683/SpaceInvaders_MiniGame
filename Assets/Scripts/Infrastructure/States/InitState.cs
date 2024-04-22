using SpaceInvadersMiniGame;
using CustomStateMachine;
using UnityEngine.Playables;
using System.Collections.Generic;

namespace SpaceInvadersMiniGame
{
    public class InitState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Dependencies cont;

        public InitState(MiniGame owner, StateMachine stateMachine, Dependencies cont)
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
            cont.EnemyFactory = new(cont.AIInput, cont.GameScreen.EnemySpawnPoints, cont.GameScreen.EnemiesParent, cont.BulletFactory);

            //Init prefab components 
            cont.GameScreen.Init(cont.Input);
            cont.AIInput.Init(cont.GameConfig.AiConfig);

            //=>
            stateMachine.EnterState<StartGameState>();
        }

        public void OnExit()
        {

        }
    }
}