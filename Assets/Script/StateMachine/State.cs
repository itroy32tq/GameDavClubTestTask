using PoketZone;
using UnityEngine;

namespace Script.StateMachine
{
    public abstract class State: ScriptableObject
    {
        [SerializeField] private string _stateId;
        private bool _needTransition = false;
        public bool NeedTransition { get => _needTransition; protected set => _needTransition = value; }
        public State TargetState { get; set; }
        public string StateId { get => _stateId; }
        public virtual void Enter() { _needTransition = false; }
        public virtual void Exit() { }
        public virtual void Update() { }
        

    }
}
