using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class FollowToTargetEnemyState : EnemyMovementState
    {
        public FollowToTargetEnemyState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private bool _reachedCheckAvailable;

        public override void Start()
        {
            base.Start();

            _reachedCheckAvailable = false;
            Context.AIDestinationSetter.target = Context.Target;
            Context.StartCoroutine(MakeReachedCheckAvailable());
        }

        public override void Stop()
        {
            base.Stop();

            Context.AIDestinationSetter.target = null;
        }

        public override void Update()
        {
            base.Update();

            if (IsEnemyLeaveAggressionArea())
            {
                StateSwitcher.SwitchState<FollowToOriginEnemyState>();
                return;
            }

            if(IsAttackAvailable())
            {
                StateSwitcher.SwitchState<EnemyStartAttackState>();
                return;
            }
        }

        private bool IsEnemyLeaveAggressionArea()
        {
            return Context.Target == null
                || Vector2.Distance(Context.transform.position, Context.OriginPosition) > Context.FinishAggressionRadius;
        }

        private bool IsAttackAvailable()
        {
            return Context.IsAttackAvailable
                && _reachedCheckAvailable
                && Context.AIPath.reachedEndOfPath;
        }

        private IEnumerator MakeReachedCheckAvailable()
        {
            yield return null;

            _reachedCheckAvailable = true;
        }
    }
}
