using Assets.Scripts.Models;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerArcherAttackState : BasePlayerAttackState
    {
        public PlayerArcherAttackState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private Vector2 _attackDirection;

        protected override AttackData AttackData => Context.ArcherAttackData;

        public override void Attack() { }

        public override void Start()
        {
            base.Start();
            _attackDirection = CalculateLookDirection();
            Context.AnimationController.SetLookDirection(CalculateLookDirection());
            Context.AnimationController.TriggerAttack();
            Context.StartCoroutine(CreateArrow());
            Context.StartCoroutine(FinishAttack());
        }

        private IEnumerator CreateArrow()
        {
            yield return new WaitForSeconds(AttackData.Delay * AttackData.Time);

            GameObject arrowObject = Object.Instantiate(Context.ArrowPrefab, Context.transform);
            arrowObject.transform.SetParent(null);

            ArrowScript arrowScript = arrowObject.GetComponent<ArrowScript>();
            arrowScript.Damage = AttackData.Damage;
            arrowScript.Owner = Context.Player;
            arrowScript.TargetTag = Context.TargetTag;

            SetArrowAngle(arrowObject, _attackDirection);
        }

        private void SetArrowAngle(GameObject arrow, Vector2 direction)
        {
            float angle = Vector2.SignedAngle(Vector2.right, direction);

            Vector3 angles = arrow.transform.eulerAngles;
            angles.z = angle;
            arrow.transform.eulerAngles = angles;
        }

        private IEnumerator FinishAttack()
        {
            yield return new WaitForSeconds(AttackData.Time);

            StateSwitcher.SwitchState<PlayerIdleState>();
        }
    }
}
