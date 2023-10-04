
using PoketZone;
using Script.Configurations;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    public abstract class SpawnerState: State
    {
        [HideInInspector] public SpawnManager Manager { get; set; }

        protected GameManagerConfig CurrentConfig;
        
        protected int CurrentIndes;
        protected List<GameManagerConfig> Configs => Manager.Configs;
        protected int Count => Configs.Count;

        public void SetConfig(int index)
        {
            CurrentConfig = Configs[index];
        }
    }
}
