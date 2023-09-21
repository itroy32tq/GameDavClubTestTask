using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class StateMachine
    {
        private State _currentState;
        public State CurrentState { get=> _currentState; protected set => _currentState = value; }
        protected Dictionary<Type, State> StateMap { get; set; }

        protected State GetStateByType<T>() where T : State
        {
            return StateMap[typeof(T)];
        }

        public void SetCurrentState(State newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        public abstract void Initialize();
    }
}
