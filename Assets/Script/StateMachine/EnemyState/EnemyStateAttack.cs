using PoketZone;
using System;
using UnityEngine;

namespace Script.StateMachine
{

    public class EnemyStateAttack : EnemyState
    {
        [SerializeField, Range(1.5f, 5f)] private float _attackDistance;
        private Vector2 _direction;
        public override void Update()
        {
            _direction = Enemy.GetDistanceToTarget();

            if (isPlayerAlive() && IsCanAttack())
            {
                Debug.Log("Атака");
            }
            else if (!IsCanAttack())
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[0];
            }
            else
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[1];
            }

        }

        private bool isPlayerAlive()
        {
            return Enemy.Target.Health > 0;
        }

        private bool IsCanAttack()
        {
            return _direction.SqrMagnitude() <= _attackDistance * _attackDistance;
        }

    }
}
