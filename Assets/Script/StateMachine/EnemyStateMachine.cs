using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class EnemyStateMachine : StateMachine
    {
        private Enemy _enemy;

        public EnemyStateMachine(Enemy enemy)
        { 
            _enemy = enemy;
            Initialize();
        }

        public override void Initialize()
        {
            StateMap = new();

            var enemyStates = Resources.LoadAll<State>("EnymyState");

            foreach (EnemyState state in enemyStates)
            {
                state.Enemy = _enemy;
                StateMap[state.GetType()] = state;
            }
            SetDefaultState();
        }

        private void SetDefaultState()
        {
            SetCurrentState(GetStateByType<EnemyStateIdle>());
        }
    }
}
