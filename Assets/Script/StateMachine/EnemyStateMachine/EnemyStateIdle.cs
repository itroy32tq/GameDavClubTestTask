using Assets.Script.Interfaces;
using PoketZone;
using UnityEngine;

namespace Assets.Script.StateMachine
{
    public class EnemyStateIdle : EnemyState, ITickable
    {
        private float _visibilityDistance;
        private float _timer = 0f;

        public EnemyStateIdle(Enemy initializer) : base(initializer)
        {
            _visibilityDistance = Initializer.VisibilityDistance;
        }

        public override void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer < 0.3f) return;
            if (IsTargetExist() && IsPlayerSight())
            {
                //todo
                Initializer.ESM.SwitchState<EnemyStateSeek>();
                _timer = 0f;
            }
        }
        private bool IsTargetExist()
        {
            return Initializer.Target != null;
        }
        private bool IsPlayerSight()
        {
            return Initializer.GetDistanceToTarget().sqrMagnitude <= _visibilityDistance * _visibilityDistance;
        }
    }
}
