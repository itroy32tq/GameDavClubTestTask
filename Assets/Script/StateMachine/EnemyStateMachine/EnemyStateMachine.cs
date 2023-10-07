using Assets.Script.Interfaces;

namespace Assets.Script.StateMachine
{
    public class EnemyStateMachine<Enemy> : StateMachine<Enemy>
    {
        
        public EnemyState CurState { get => (EnemyState)CurrentState; }
        public EnemyStateMachine(params IState<Enemy>[] states) : base(states)
        {

        }
        public override void SwitchState<EnemyState>()
        {
            TryExitPreviosState<EnemyState>();
            GetNewState<EnemyState>();
            TryEnterNewState<EnemyState>();
        }
    }
}
