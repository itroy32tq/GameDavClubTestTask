
using UnityEngine;

namespace Script.StateMachine
{
    public class SpawnerStateMachine: StateMachine
    {
        public SpawnerStateMachine()
        {
            Initialize();
        }
        public override void Initialize()
        {
            StateMap = new();

            var enemyStates = Resources.LoadAll<State>("SpawnerStates");

            foreach (EnemyState state in enemyStates)
            {
                StateMap[state.GetType()] = state;
            }
            SetDefaultState();
        }
        private void SetDefaultState()
        {
            SetCurrentState(GetStateByType<SpawnerStateIdle>());
        }
    }
}
