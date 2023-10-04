using PoketZone;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    public abstract class EnemyState : State
    {
        
        [HideInInspector] public Enemy Enemy { get; set; }
    }
}
