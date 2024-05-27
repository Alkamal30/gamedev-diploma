using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossIdleState : BaseBossState
    {
        public BossIdleState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            base.Start();

            Context.Wave = 0;
            Context.HitPoints = Context.MaximalHitPoints;
        }

        public override void Stop()
        {
            base.Stop();
        }

        public override void Update()
        {
            base.Update();

            Collider2D[] colliders = Physics2D.OverlapCircleAll(Context.OriginPosition, Context.StartAggressionRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    ToAggressTarget(collider.transform);
                }
            }
        }

        public override void ToAggress(Transform target)
        {
            ToAggressTarget(target);
        }

        private void ToAggressTarget(Transform target)
        {
            Context.OnBossFightStarted.Invoke();
            Context.Target = target;
            Context.Wave = 1;
            Context.StartCoroutine(StartBossFight());
        }

        private IEnumerator StartBossFight()
        {
            yield return new WaitForSeconds(2f);

            StateSwitcher.SwitchState<BossFollowToTargetState>();
        }
    }
}
