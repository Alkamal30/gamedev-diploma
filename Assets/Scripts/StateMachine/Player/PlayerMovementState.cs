using Assets.Scripts.StateMachine.Player;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class PlayerMovementState : BasePlayerState
    {
        public PlayerMovementState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            Context.AnimationController.SetMovingFlag(true);
        }

        public override void Stop()
        {
            Rigidbody.velocity = Vector2.zero;
            Context.AnimationController.SetMovingFlag(false);
        }

        public override void Update()
        {
            base.Update();
            Move();
            Jerk();
        }

        public override void Attack()
        {
            if (Context.IsAttackAvailable)
            {
                StateSwitcher.SwitchState<BasePlayerAttackState>();
            }
        }

        private void Move()
        {
            Vector2 axisValues = GetAxisValues();

            Rigidbody.velocity = axisValues.normalized * Context.MovementSpeed;
            Context.AnimationController.SetMovementDirection(Rigidbody.velocity);

            if (axisValues.x == 0f && axisValues.y == 0f)
            {
                StateSwitcher.SwitchState<PlayerIdleState>();
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
