using Assets.Script.Interfaces;
using PoketZone;
using UnityEngine;

namespace Assets.Script.StateMachine
{
    public abstract class EnemyState : IState<Enemy>, IEnterable, IExitable, ITickable
    {
        public Enemy Initializer { get; protected set; }

        protected EnemyState(Enemy initializer)
        {
            Initializer = initializer;
        }
        public virtual void OnEnter()
        {

        }
        public virtual void OnExit()
        {

        }

        public virtual void Tick()
        {
            
        }
    }
}
