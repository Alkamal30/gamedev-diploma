using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    internal class BossAggressiveAttackState : BaseBossState
    {
        public BossAggressiveAttackState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private bool _isAttack;

        public override void Start()
        {
            base.Start();

            _isAttack = true;
            Context.StartCoroutine(SpawnWave());
        }

        public override void Stop()
        {
            base.Stop();
        }

        public override void Dead()
        {
            base.Dead();

            _isAttack = false;
        }

        private IEnumerator SpawnWave()
        {
            while(_isAttack)
            {
                Context.AnimationController.TriggerAttack();
                Context.DynamiteRain.SpawnNextWave();

                yield return new WaitForSeconds(Context.AggressiveAttackData.BetweenAttackDelay);
            }
        }
    }
}
