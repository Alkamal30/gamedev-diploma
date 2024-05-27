using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossDeadState : BaseBossState
    {
        public BossDeadState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            base.Start();
            Context.AIPath.enabled = false;
            Context.Collider.isTrigger = true;
            Context.AnimationController.TriggerDead();
            Context.StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(Context.DeadDelay);

            Object.Destroy(Context.gameObject);
        }
    }
}
