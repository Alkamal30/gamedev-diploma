using Assets.Scripts.Models;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public abstract class BasePlayerAttackState : BasePlayerState
    {
        protected BasePlayerAttackState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        protected abstract AttackData AttackData { get; }

        public override void Start()
        {
            base.Start();
            Context.IsAttackAvailable = false;
        }

        public override void Stop()
        {
            base.Stop();
            Context.IsAttackAvailable = false;
            Context.StartCoroutine(MakeAttackAvailable());
        }

        private IEnumerator MakeAttackAvailable()
        {
            yield return new WaitForSeconds(AttackData.BetweenAttackDelay);

            Context.IsAttackAvailable = true;
        }
    }
}
