using UnityEngine;

namespace PoketZone
{
    public abstract class Enemy : Unit
    {
        [SerializeField] private string _name;
        [SerializeField, Range(1f,10f)] int _reward;

        //todo
        [SerializeField] private PlayerController _target;
        protected int Reward => _reward;
        protected EnemyStateMachine ESM { get; private set; }

        public PlayerController Target => _target;

        protected override void Start()
        { 
            base.Start();
            ESM = new EnemyStateMachine(this);
        }
        public void Init(PlayerController player) 
        { 
            _target = player;
        }

        protected void Update()
        {
            if (ESM != null) 
            {
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
