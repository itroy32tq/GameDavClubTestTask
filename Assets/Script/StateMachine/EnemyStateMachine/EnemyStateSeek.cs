using Assets.Script.Interfaces;
using PoketZone;
using UnityEngine;

namespace Assets.Script.StateMachine
{
    public class EnemyStateSeek : EnemyState, ITickable
    {
        private float _attackDistance;
        private Vector2 _direction;
        private float _timer = 0f;

        public EnemyStateSeek(Enemy initializer) : base(initializer)
        {
            _attackDistance = Initializer.AttackDistance;
        }
        public override void OnExit()
        {
            base.OnExit();
            Initializer.MakeMove(Vector2.zero);
        }

        public override void Tick()
        {

            _timer += Time.deltaTime;

            if (_timer < 0.3f) return;

            _direction = Initializer.GetDistanceToTarget();

            if (!IsCanAttack())
            {
                Initializer.MakeMove(_direction.normalized);
            }
            else
            {
                Initializer.ESM.SwitchState<EnemyStateAttack>();
            }
            _timer = 0f;
        }

        private bool IsCanAttack()
        {
            return _direction.SqrMagnitude() <= _attackDistance * _attackDistance;
        }
    }
}
