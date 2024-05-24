using Assets.Scripts.Models;
using Assets.Scripts.StateMachine.Player;

namespace Assets.Scripts.StateMachine
{
    public class PlayerWarriorLongAttackState : BasePlayerWarriorAttackState
    {
        public PlayerWarriorLongAttackState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        protected override AttackData AttackData => Context.LongAttackData;

        protected override void TriggerAttackAnimation()
        {
            Context.AnimationController.TriggerLongAttack();
        }

        protected override void SwitchState()
        {
            StateSwitcher.SwitchState<PlayerIdleState>();
        }
    }
}
