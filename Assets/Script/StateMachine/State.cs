using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    public abstract class State: ScriptableObject
    {
        [SerializeField] private string _stateId;
        [SerializeField] private List<State> _availableTransitions;
        private bool _needTransition = false;
        
        protected List<State> AvailableTransitions => _availableTransitions;

        public bool NeedTransition { get => _needTransition; protected set => _needTransition = value; }
        public State TargetState { get; set; }
        public string StateId { get => _stateId; }
        public virtual void Enter() { _needTransition = false; }
        public virtual void Exit() { }
        public abstract void Update();
    }
}
