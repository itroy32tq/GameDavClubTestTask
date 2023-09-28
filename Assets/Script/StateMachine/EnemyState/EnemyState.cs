using PoketZone;
using System.Collections.Generic;
using UnityEngine;

namespace Script.StateMachine
{
    [CreateAssetMenu(fileName = "EnemyState", menuName = "State/EnemyState")]
    public abstract class EnemyState : State
    {
        [SerializeField] private List<EnemyState> _availableTransitions;
        protected List<EnemyState> AvailableTransitions => _availableTransitions;
        [HideInInspector] public Enemy Enemy { get; set; }
    }
}
