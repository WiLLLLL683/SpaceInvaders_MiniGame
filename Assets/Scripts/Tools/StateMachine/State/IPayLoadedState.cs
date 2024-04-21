namespace CustomStateMachine
{
    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        public void OnEnter(TPayLoad payLoad);
    }
}