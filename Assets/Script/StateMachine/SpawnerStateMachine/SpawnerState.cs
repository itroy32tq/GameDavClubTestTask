
using Assets.Script.Interfaces;
using PoketZone;
using Script.Configurations;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    public abstract class SpawnerState : IState<SpawnManager>, IEnterable, IExitable
    {
        public SpawnManager Initializer { get; protected set; }

        protected List<GameManagerConfig> Configs => Initializer.Configs;
        protected GameManagerConfig CurrentConfig  { get => Initializer.CurrentConfig; set => Initializer.CurrentConfig = value; }
        protected int CurrentIndex { get => Initializer.CurrentIndex; set => Initializer.CurrentIndex = value; }
        protected int Count => CurrentConfig.Count;

        protected void SetCurrentConfig(int index)
        { 
            CurrentConfig = Configs[index];
        }
        public SpawnerState(SpawnManager initializer)
        {
            Initializer = initializer;
        }
        public virtual void OnEnter()
        {
            
        }
        public virtual void OnExit()
        {
           
        }
    }
}
