using CustomStateMachine;
using System;

namespace SpaceInvadersMiniGame
{
    public class WinState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Container cont;

        public WinState(MiniGame owner, StateMachine stateMachine, Container cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //=>
            cont.GameScreen.Hide();
            owner.Disable();
        }

        public void OnExit()
        {

        }
    }
}