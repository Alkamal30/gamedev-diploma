using Assets.Scripts.StateMachine.Player;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class PlayerIdleState : BasePlayerState
    {
        public PlayerIdleState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Update()
        {
            base.Update();
            Jerk();

            Vector2 axisValues = GetAxisValues();

            Rigidbody.velocity = axisValues * Context.MovementSpeed;

            if(axisValues.x == 0f && axisValues.y == 0f)
            {
                return;
            }

            StateSwitcher.SwitchState<PlayerMovementState>();
        }

        public override void Attack()
        {
            if (Context.IsAttackAvailable)
            {
                StateSwitcher.SwitchState<BasePlayerAttackState>();
            }
        }

        private void Jerk()
        {
            if (IsJerkAvailable())
            {
                StateSwitcher.SwitchState<PlayerJerkState>();
            }
        }
    }
}
