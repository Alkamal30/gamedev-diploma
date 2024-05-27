using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossAttackState : BaseBossState
    {
        public BossAttackState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            base.Start();

            Context.AnimationController.SetLookDirection(GetLookDirection());
            Context.AnimationController.TriggerAttack();
            Context.IsAttackAvailable = false;
            Context.StartCoroutine(CreateDynamiteObject());
            Context.StartCoroutine(FinishAttack());
        }

        public override void Stop()
        {
            base.Stop();

            Context.StartCoroutine(MakeAttackAvailable());
        }

        private IEnumerator CreateDynamiteObject()
        {
            yield return new WaitForSeconds(Context.AttackData.Delay * Context.AttackData.Time);

            GameObject dynamite = Object.Instantiate(Context.DynamitePrefab, Context.transform);
            dynamite.transform.SetParent(null);

            DynamiteScript dynamiteScript = dynamite.GetComponent<DynamiteScript>();
            dynamiteScript.TargetPosition = Context.Target.transform.position;
            dynamiteScript.Duration = Context.Wave <= 1 ? Context.FirstWaveDynamiteDuration: Context.SecondWaveDynamiteDuration;
        }

        private IEnumerator FinishAttack()
        {
            yield return new WaitForSeconds(Context.AttackData.Time);

            if(Context.Wave == 3)
            {
                StateSwitcher.SwitchState<BossAggressiveAttackState>();
            }
            else
            {
                StateSwitcher.SwitchState<BossFollowToTargetState>();
            }
        }

        private IEnumerator MakeAttackAvailable()
        {
            yield return new WaitForSeconds(Context.AttackData.BetweenAttackDelay);

            Context.IsAttackAvailable = true;
        }

        private Vector2 GetLookDirection()
        {
            return (Context.Target.position - Context.transform.position).normalized;
        }
    }
}
