using CustomStateMachine;

namespace SpaceInvadersMiniGame
{
    public class StartGameState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Container cont;

        public StartGameState(MiniGame owner, StateMachine stateMachine, Container cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //Reset per-game data
            cont.GameData.Reset();

            //Show UI
            cont.GameScreen.Show();

            //=>
            stateMachine.EnterState<GamePlayState, int>(0);
        }

        public void OnExit()
        {

        }
    }
}