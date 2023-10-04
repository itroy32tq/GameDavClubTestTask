using PoketZone;
using UnityEngine;

namespace Script.StateMachine
{
    public class EnemyStateMachine : StateMachine
    {
        public EnemyStateMachine()
        { 
            Initialize();
        }
        public override void Initialize()
        {
            StateMap = new();

            var enemyStates = Resources.LoadAll<State>("EnymyState");

            foreach (EnemyState state in enemyStates)
            {
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
