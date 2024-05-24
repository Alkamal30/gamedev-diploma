using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class EnemyIdleState : BaseEnemyState
    {
        public EnemyIdleState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void ToAggress(Transform target)
        {
            base.ToAggress(target);
            ToAggressTarget(target);
        }

        public override void Update()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Context.OriginPosition, Context.StartAggressionRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    ToAggressTarget(collider.transform);
                }
            }
        }

        private void ToAggressTarget(Transform target)
        {
            Context.Target = target;
            StateSwitcher.SwitchState<FollowToTargetEnemyState>();
        }
    }
}
