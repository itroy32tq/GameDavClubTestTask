using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Script.StateMachine
{
    [CreateAssetMenu(fileName = "SpawnerStateIdle", menuName = "State/SpawnerState/SpawnerStateIdle")]
    public class SpawnerStateIdle: SpawnerState
    {
        public override void Update()
        {
            if (IsTransitionExist())
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[0];
            }
        }
        public override void Enter()
        {
            base.Enter();
            if (IsConfigerationExist()) 
                SetConfig(CurrentIndes);
        }
        private bool IsConfigerationExist()
        {
            return Configs != null && Configs[0] != null;
        }

        private bool IsTransitionExist()
        {
            return AvailableTransitions[0] != null;
        }
    }
}
