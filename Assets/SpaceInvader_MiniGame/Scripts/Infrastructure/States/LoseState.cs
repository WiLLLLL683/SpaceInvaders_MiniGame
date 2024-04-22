using CustomStateMachine;
using System;

namespace SpaceInvadersMiniGame
{
    public class LoseState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Container cont;

        public LoseState(MiniGame owner, StateMachine stateMachine, Container cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //=>
            cont.GameScreen.Hide();
            stateMachine.EnterState<StartGameState>();
        }

        public void OnExit()
        {

        }
    }
}