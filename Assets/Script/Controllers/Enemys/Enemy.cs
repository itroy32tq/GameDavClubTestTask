using Script.StateMachine;
using UnityEngine;

namespace PoketZone
{
    public abstract class Enemy : Unit
    {
        [SerializeField] private string _name;
        private PlayerController _target;

        protected EnemyStateMachine ESM { get; private set; }

        public PlayerController Target => _target;
        protected override void Start()
        { 
            base.Start();
            ESM = new EnemyStateMachine();
        }
        public void Init(PlayerController player) 
        { 
            _target = player;
        }
        protected void Update()
        {
            if (ESM != null) 
            {
                var state = (EnemyState)ESM.CurrentState;
                state.Enemy = this;
                ESM.CurrentState.Update();

                if (ESM.CurrentState.NeedTransition)
                {
                    ESM.SetCurrentState(ESM.CurrentState.TargetState);
                }
            }
        }
        public Vector2 GetDistanceToTarget()
        {
            return Target.transform.position - transform.position;
        }
    }
}
