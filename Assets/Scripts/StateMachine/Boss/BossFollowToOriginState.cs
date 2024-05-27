using Assets.Scripts.StateMachine.Enemy;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossFollowToOriginState : BossMovementState
    {
        public BossFollowToOriginState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private float _oldEndReachedDistance;

        public override void Start()
        {
            base.Start();

            _oldEndReachedDistance = Context.AIPath.endReachedDistance;
            Context.AIPath.endReachedDistance = 0.1f;
            Context.AIPath.destination = Context.OriginPosition;
            Context.HitPoints = Context.MaximalHitPoints;
        }

        public override void Stop()
        {
            base.Stop();

            Context.AIPath.endReachedDistance = _oldEndReachedDistance;
        }

        public override void Update()
        {
            base.Update();

            if (Context.AIPath.reachedEndOfPath)
            {
                StateSwitcher.SwitchState<BossIdleState>();
            }
        }
    }
}
