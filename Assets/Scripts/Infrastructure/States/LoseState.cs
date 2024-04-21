using CustomStateMachine;
using System;

namespace SpaceInvadersMiniGame
{
    public class LoseState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Dependencies cont;

        public LoseState(MiniGame owner, StateMachine stateMachine, Dependencies cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //=>
            stateMachine.EnterState<StartGameState>();
        }

        public void OnExit()
        {

        }
    }
}