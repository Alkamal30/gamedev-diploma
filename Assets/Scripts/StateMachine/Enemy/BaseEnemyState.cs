using Assets.Scripts.StateMachine.Base;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class BaseEnemyState : BaseState<EnemyStateContext>
    {
        public BaseEnemyState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public virtual void Dead()
        {
            StateSwitcher.SwitchState<EnemyDeadState>();
        }

        public virtual void ToAggress(Transform target) { }
    }
}
