using Assets.Scripts.StateMachine.Base;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossStateBehaviour : BaseStateBehaviour<BossStateContext>
    {
        [SerializeField] private BossStateContext _context;

        protected new BaseBossState CurrentState => base.CurrentState as BaseBossState;

        public void ToAggress(Transform target)
        {
            CurrentState.ToAggress(target);
        }

        public void Dead()
        {
            CurrentState.Dead();
        }

        protected override void InitializeStates(List<BaseState<BossStateContext>> statesList)
        {
            statesList.AddRange(new List<BaseState<BossStateContext>>
            {
                new BossIdleState(this, _context),
                new BossDeadState(this, _context),
                new BossFollowToTargetState(this, _context),
                new BossFollowToOriginState(this, _context),
            });

            SwitchState<BossIdleState>();
        }

        private void OnDrawGizmos()
        {
            if (_context.IsDrawGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_context.OriginPosition, _context.StartAggressionRadius);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(_context.OriginPosition, _context.FinishAggressionRadius);
            }
        }
    }
}
