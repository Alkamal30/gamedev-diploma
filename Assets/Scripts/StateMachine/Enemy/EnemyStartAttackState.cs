using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class EnemyStartAttackState : BaseEnemyState
    {
        public EnemyStartAttackState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            Context.AnimationController.TriggerStartAttack();
            Context.StartCoroutine(AttackDelay());
        }

        public override void Update()
        {
            if(Context.Target == null)
            {
                StateSwitcher.SwitchState<FollowToOriginEnemyState>();
                return;
            }

            Context.AnimationController.SetLookDirection(GetLookDirection());
        }

        private IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(Context.BeforeAttackDelay);

            StateSwitcher.SwitchState<EnemyAttackState>();
        }

        private Vector2 GetLookDirection()
        {
            return (Context.Target.position - Context.transform.position).normalized;
        }
    }
}
