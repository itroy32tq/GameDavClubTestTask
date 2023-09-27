using PoketZone;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    public class EnemyStateIdle : EnemyState
    {
        [SerializeField, Range(10f, 15f)] float visibilityDistance;
        public override void Update()
        {
            if (IsTargetExist() && IsPlayerSight())
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[0];
            }
        }

        private bool IsTargetExist()
        {
            return AvailableTransitions[0] != null && Enemy.Target != null;
        }
        private bool IsPlayerSight()
        {
            return Enemy.GetDistanceToTarget().sqrMagnitude <= visibilityDistance * visibilityDistance;
        }
    }
}
