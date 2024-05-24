using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class EnemyMovementState : BaseEnemyState
    {
        public EnemyMovementState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
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
