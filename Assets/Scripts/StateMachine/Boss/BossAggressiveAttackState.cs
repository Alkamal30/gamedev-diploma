namespace Assets.Scripts.StateMachine.Boss
{
    internal class BossAggressiveAttackState : BaseBossState
    {
        public BossAggressiveAttackState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }


    }
}
