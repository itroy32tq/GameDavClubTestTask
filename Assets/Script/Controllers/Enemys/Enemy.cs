using Assets.Script.Interfaces;
using Assets.Script.StateMachine;
using Script.StateMachine;
using UnityEngine;

namespace PoketZone
{
    public abstract class Enemy : Unit
    {
        [SerializeField] private string _name;
        [SerializeField, Range(0f, 25f)] private float _visibilityDistance;
        [SerializeField, Range(1.5f, 5f)] private float _attackDistance;
        private PlayerController _target;
        public float VisibilityDistance => _visibilityDistance;
        public float AttackDistance => _attackDistance;
        public EnemyStateMachine<Enemy> ESM { get; private set; }

        public PlayerController Target => _target;
        protected override void Start()
        { 
            base.Start();
            ESM = new EnemyStateMachine<Enemy>(new EnemyStateIdle(this), new EnemyStateSeek(this), new EnemyStateAttack(this));
            ESM.SwitchState<EnemyStateIdle>();
        }

        public void Update()
        {
            ESM.CurState?.Tick();
        }
        public void Init(PlayerController player) 
        { 
            _target = player;
        }
     
        public Vector2 GetDistanceToTarget()
        {
            return Target.transform.position - transform.position;
        }
    }
}
