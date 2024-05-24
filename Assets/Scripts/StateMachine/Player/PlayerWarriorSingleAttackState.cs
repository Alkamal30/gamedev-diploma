using Assets.Scripts.Models;
using Assets.Scripts.StateMachine.Player;

namespace Assets.Scripts.StateMachine
{
    public class PlayerWarriorSingleAttackState : BasePlayerWarriorAttackState
    {
        public PlayerWarriorSingleAttackState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private bool _isCombo;

        protected override AttackData AttackData => Context.SingleAttackData;

        public override void Attack()
        {
            base.Attack();
            _isCombo = true;
        }

        public override void Start()
        {
            base.Start();
            _isCombo = false;
        }

        protected override void TriggerAttackAnimation()
        {
            Context.AnimationController.TriggerSingleAttack();
        }

        protected override void SwitchState()
        {
            if (_isCombo)
            {
                StateSwitcher.SwitchState<PlayerWarriorLongAttackState>();
            }
            else
            {
                StateSwitcher.SwitchState<PlayerIdleState>();
            }
        }
    }
}
