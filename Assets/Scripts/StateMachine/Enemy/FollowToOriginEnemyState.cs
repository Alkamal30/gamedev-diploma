using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class FollowToOriginEnemyState : EnemyMovementState
    {
        public FollowToOriginEnemyState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
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
                StateSwitcher.SwitchState<EnemyIdleState>();
            }
        }
    }
}
