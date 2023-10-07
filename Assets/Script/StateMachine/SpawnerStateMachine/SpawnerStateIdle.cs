using Assets.Script.Interfaces;
using Assets.Script.StateMachine;
using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Script.StateMachine
{
    public class SpawnerStateIdle : SpawnerState
    {
        public SpawnerStateIdle(SpawnManager initializer) : base(initializer)
        {

        }
        public override void OnEnter()
        {
            if (IsConfigerationExist())
            {
                SetCurrentConfig(CurrentIndex);
                Initializer.SSM.SwitchState<SpawnerStateWork>();
            }

        }
        private bool IsConfigerationExist()
        {
            return CurrentIndex < Configs.Count && Configs != null && Configs[CurrentIndex] != null;
        }
    }
}
