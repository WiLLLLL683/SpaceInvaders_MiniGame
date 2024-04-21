using CustomStateMachine;
using System;

namespace SpaceInvadersMiniGame
{
    public class LevelClearedState : IState
    {
        private readonly MiniGame owner;
        private readonly StateMachine stateMachine;
        private readonly Dependencies cont;

        public LevelClearedState(MiniGame owner, StateMachine stateMachine, Dependencies cont)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
            this.cont = cont;
        }

        public void OnEnter()
        {
            //Check win condition
            cont.GameData.CurrentLevelIndex++;
            bool allLevelsCleared = cont.GameData.CurrentLevelIndex >= cont.LevelsConfig.Count;

            //=>
            if (allLevelsCleared)
            {
                stateMachine.EnterState<WinState>();
            }
            else
            {
                stateMachine.EnterState<GamePlayState, int>(cont.GameData.CurrentLevelIndex);
            }
        }

        public void OnExit()
        {

        }
    }
}