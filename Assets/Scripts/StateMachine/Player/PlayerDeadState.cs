using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerDeadState : BasePlayerState
    {
        public PlayerDeadState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Attack() { }

        public override void Start()
        {
            base.Start();
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
