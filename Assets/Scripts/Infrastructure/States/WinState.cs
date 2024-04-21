using CustomStateMachine;
using System;

namespace SpaceInvadersMiniGame
{
    public class WinState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Dependencies cont;

        public WinState(MiniGame owner, StateMachine stateMachine, Dependencies cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //=>
            owner.Disable();
        }

        public void OnExit()
        {

        }
    }
}