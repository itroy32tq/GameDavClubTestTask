using Assets.Script.Interfaces;
using PoketZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StateMachine
{
    public class EnemyStateAttack : EnemyState, ITickable
    {
        private float _attackDistance;
        private Vector2 _direction;
        private float _timer = 0f;

        public EnemyStateAttack(Enemy initializer) : base(initializer)
        {
            _attackDistance = Initializer.AttackDistance;
        }
        public override void Tick()
        {
            _timer += Time.deltaTime;
            
            if (_timer < 0.3f) return;

            _direction = Initializer.GetDistanceToTarget();

            if (IsPlayerAlive() && IsCanAttack())
            {
                Debug.Log("Атака");
                //конкретной реализации атаки не делал, если это не выстрел, то без анимация выглядит максимально нелепо
            }
            else if (!IsCanAttack())
            {
                Initializer.ESM.SwitchState<EnemyStateSeek>();
            }
            else
            {
                Initializer.ESM.SwitchState<EnemyStateIdle>();
            }
            _timer = 0f;
        }
        private bool IsPlayerAlive()
        {
            return Initializer.Target.Health > 0;
        }

        private bool IsCanAttack()
        {
            return _direction.SqrMagnitude() <= _attackDistance * _attackDistance;
        }
    }
}
