using Assets.Scripts.StateMachine.Base;

namespace Assets.Scripts.StateMachine
{
    public interface IStateSwitcher<TContext> where TContext : StateContext
    {
        public void SwitchState<TState>() where TState : BaseState<TContext>;
    }
}