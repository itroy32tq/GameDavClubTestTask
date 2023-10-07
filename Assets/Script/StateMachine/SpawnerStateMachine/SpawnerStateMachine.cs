
using Assets.Script.Interfaces;
using PoketZone;
using UnityEngine;

namespace Script.StateMachine
{
    public class SpawnerStateMachine<SpawnManager> : StateMachine<SpawnManager>
    {
        public SpawnerStateMachine(params IState<SpawnManager>[] states) : base(states)
        {

        }

    }
}
