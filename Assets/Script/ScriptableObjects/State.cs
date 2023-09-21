using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class State: ScriptableObject
    {
        private bool _needTransition = false;
        public bool NeedTransition { get => _needTransition; protected set => _needTransition = value; }
        public State TargetState { get; set; }

        public virtual void Enter() { _needTransition = false; }
        public virtual void Exit() { }
        public virtual void Update() { }

    }
}
