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
            cont.EnemiesData = new();

            //Create factories
            cont.BulletFactory = new(cont.GameScreen.BulletParent);
            cont.PlayerFactory = new(cont.GameScreen.PlayerSpawnPoint, cont.GameScreen.PlayerParent, cont.Input, cont.BulletFactory, cont.PlayerConfig);
            cont.EnemyFactory = new(cont.EnemiesData, cont.GameScreen.EnemySpawnPoints, cont.GameScreen.EnemiesParent, cont.BulletFactory);

            //Init UI
            cont.GameScreen.Init(owner, cont.Input);

            //=>
            stateMachine.EnterState<StartGameState>();
        }

        public void OnExit()
        {

        }
    }
}