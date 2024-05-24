using Assets.Scripts.StateMachine.Base;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class EnemyStateBehaviour : BaseStateBehaviour<EnemyStateContext>
    {
        [SerializeField] private EnemyStateContext _context;

        protected new BaseEnemyState CurrentState => base.CurrentState as BaseEnemyState;

        public void ToAggress(Transform target)
        {
            CurrentState.ToAggress(target);
        }

        public void Dead()
        {
            CurrentState.Dead();
        }

        protected override void InitializeStates(List<BaseState<EnemyStateContext>> statesList)
        {
            statesList.AddRange(new List<BaseState<EnemyStateContext>>
            {
                new EnemyIdleState(this, _context),
                new EnemyDeadState(this, _context),
                new FollowToTargetEnemyState(this, _context),
                new FollowToOriginEnemyState(this, _context),
                new EnemyStartAttackState(this, _context),
                new EnemyAttackState(this, _context),
            });

            SwitchState<EnemyIdleState>();
        }

        private void OnDrawGizmos()
        {
            if(_context.IsDrawGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_context.OriginPosition, _context.StartAggressionRadius);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(_context.OriginPosition, _context.FinishAggressionRadius);
            }
        }
    }
}
