namespace Assets.Scripts.StateMachine.Boss
{
    public class BossMovementState : BaseBossState
    {
        public BossMovementState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            Context.AnimationController.SetMovingFlag(true);
        }

        public override void Stop()
        {
            Context.AnimationController.SetMovingFlag(false);
        }

        public override void Update()
        {
            Context.AnimationController.SetMovementDirection(Context.AIPath.desiredVelocity);
        }
    }
}
