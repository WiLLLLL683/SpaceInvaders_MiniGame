using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomStateMachine
{
    /// <summary>
    /// State machine, stores one instance for each added state of type TState
    /// </summary>
    public class StateMachine
    {
        public IExitableState CurrentState { get; private set; }

        private readonly Dictionary<Type, IExitableState> states = new();

        public void EnterState<T>() where T : IState
        {
            T newState = GetState<T>();
            if (newState == null)
                return;

            ChangeState(newState);
            newState.OnEnter();
        }

        public void EnterState<T, TPayLoad>(TPayLoad payLoad) where T : IPayLoadedState<TPayLoad>
        {
            T newState = GetState<T>();
            if (newState == null)
                return;

            ChangeState(newState);
            newState.OnEnter(payLoad);
        }

        public void ExitCurrentState() => ChangeState(null);

        public void AddState(IExitableState state)
        {
            Type type = state.GetType();
            states[type] = state;
        }

        public T GetState<T>() where T : IExitableState
        {
            if (!states.ContainsKey(typeof(T)))
            {
                Debug.LogError("Can't get state: " + typeof(T) + " - StateMachine doesn't contain this state");
                return default;
            }

            return (T)states[typeof(T)];
        }

        private void ChangeState(IExitableState newState)
        {
            CurrentState?.OnExit();
            CurrentState = newState;
        }
    }
}