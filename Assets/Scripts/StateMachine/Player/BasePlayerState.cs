using Assets.Scripts.StateMachine.Base;
using Assets.Scripts.StateMachine.Player;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public abstract class BasePlayerState : BaseState<PlayerStateContext>
    {
        public BasePlayerState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
            _rigidbody = context.GetComponent<Rigidbody2D>();
        }

        protected Rigidbody2D Rigidbody => _rigidbody;

        private Rigidbody2D _rigidbody;

        public abstract void Attack();

        public virtual void Dead()
        {
            StateSwitcher.SwitchState<PlayerDeadState>();
        }

        public override void Update()
        {
            UpdateStamina();
        }

        protected Vector2 GetAxisValues()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            return new Vector2(horizontal, vertical);
        }

        protected Vector2 CalculateLookDirection()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDirection = mousePosition - (Vector2) Context.transform.position;

            return lookDirection.normalized;
        }

        protected bool IsJerkAvailable()
        {
            return Input.GetKeyDown(KeyCode.Space)
                && Context.StaminaPoints >= 1f
                && Context.IsJerkAvailable;
        }

        private void UpdateStamina()
        {
            Context.StaminaPoints += Context.StaminaRegeneration * Time.deltaTime;
            Context.StaminaPoints = Mathf.Clamp(Context.StaminaPoints, 0f, Context.MaximalStaminaPoints);
        }
    }
}
