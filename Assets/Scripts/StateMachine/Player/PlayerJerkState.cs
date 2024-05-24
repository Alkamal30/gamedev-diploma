using Assets.Scripts.StateMachine.Player;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class PlayerJerkState : BasePlayerState
    {
        public PlayerJerkState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
            _jerkSource = null;
            _jerkTarget = null;
            _jerkStartTime = 0;
        }

        private Vector2? _jerkSource;
        private Vector2? _jerkTarget;
        private float _jerkStartTime;

        public override void Start()
        {
            _jerkStartTime = Time.time;
            _jerkSource = Context.transform.position;
            _jerkTarget = (Vector2) Context.transform.position
                + CalculateLookDirection().normalized
                * Context.JerkLength;

            Rigidbody.velocity = Vector2.zero;
        }

        public override void Stop()
        {
            _jerkSource = null;
            _jerkTarget = null;
        }

        public override void Update()
        {
            float t = (Time.time - _jerkStartTime) / Context.JerkDuration;

            Vector2 newPosition = Vector2.Lerp(_jerkSource.Value, _jerkTarget.Value, t);
            Rigidbody.MovePosition(newPosition);

            if (t >= 1f)
            {
                StateSwitcher.SwitchState<PlayerIdleState>();
            }
        }

        public override void Attack()
        {
        }
    }
}
