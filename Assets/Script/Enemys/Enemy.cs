using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public abstract class Enemy : Unit
    {
        [SerializeField] private string _name;
        [SerializeField, Range(1f,10f)] int _reward;
        
        //todo
        [SerializeField] private Player _target;
        public Player Target => _target;

        protected int Reward => _reward;
        protected EnemyStateMachine ESM { get; private set; }


        protected override void Start()
        { 
            base.Start();
            ESM = new EnemyStateMachine(this);

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


    }
}
