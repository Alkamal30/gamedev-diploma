using Assets.Scripts.StateMachine.Base;
using Assets.Scripts.StateMachine.Enemy;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BaseBossState : BaseState<BossStateContext>
    {
        public BaseBossState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public virtual void ToAggress(Transform target) { }

        public virtual void Dead()
        {
            StateSwitcher.SwitchState<BossDeadState>();
        }
    }
}
