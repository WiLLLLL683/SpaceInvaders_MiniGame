namespace CustomStateMachine
{
    public interface IState : IExitableState
    {
        public void OnEnter();
    }
}