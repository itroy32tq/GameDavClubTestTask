using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Script.Interfaces
{
    public abstract class StateMachine<TInitializer>
    {
        private IState<TInitializer> _currentState;
        private bool _isTicking;

        protected IState<TInitializer> CurrentState => _currentState;
        protected TInitializer Initializer { get; }
        protected Dictionary<Type, IState<TInitializer>> StateMap { get; set; }

        public StateMachine(params IState<TInitializer>[] states)
        {

            StateMap = new Dictionary<Type, IState<TInitializer>>(states.Length);
            foreach (var state in states) 
            { 
                StateMap.Add(state.GetType(), state);
            }
        }
        public virtual void SwitchState<TState>() where TState : IState<TInitializer>
        {
            TryExitPreviosState<TState>();
            GetNewState<TState>();
            TryEnterNewState<TState>();
            TryTickNewState<TState>();
        }

        protected void TryInitNewState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IInitable initable)
                initable.OnInit(Initializer);
        }

        protected void TryExitPreviosState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IExitable exitable)
                exitable.OnExit();
        }
        protected void GetNewState<TState>() where TState : IState<TInitializer>
        {
            _currentState = GetStateByType<TState>();
            _isTicking = false;
        }
        protected void TryTickNewState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is ITickable tickable)
            {
                _isTicking = true;
                StartTick(tickable);
            }
            else
                _isTicking = false;
        }
        private async void StartTick(ITickable tickable)
        {
            while (_isTicking)
            {
                tickable.Tick();
                await Task.Yield();
            }
        }
        protected void TryEnterNewState<TState>() where TState : IState<TInitializer>
        {
            if (_currentState is IEnterable enterable)
                enterable.OnEnter();
        }
        protected TState GetStateByType<TState>() where TState : IState<TInitializer>
        {
            return (TState)StateMap[typeof(TState)];
        }
    }
}
