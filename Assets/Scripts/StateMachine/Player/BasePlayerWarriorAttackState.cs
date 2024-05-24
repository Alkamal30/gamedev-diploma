using Assets.Scripts.Abstraction;
using Assets.Scripts.Models;
using Assets.Scripts.StateMachine.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public abstract class BasePlayerWarriorAttackState : BasePlayerAttackState
    {
        public BasePlayerWarriorAttackState(IStateSwitcher<PlayerStateContext> stateSwitcher, PlayerStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private float _elapsedTime;

        public override void Attack() { }

        public override void Start()
        {
            base.Start();
            _elapsedTime = 0f;
        }

        public override void Update()
        {
            base.Update();
            TryToAttack();
            UpdateAttackDelay();
        }

        protected abstract void TriggerAttackAnimation();

        protected abstract void SwitchState();

        private void TryToAttack()
        {
            if (_elapsedTime <= 0f)
            {
                InvokeAttack();

                _elapsedTime = AttackData.Time;
            }
        }

        private void UpdateAttackDelay()
        {
            _elapsedTime -= Time.deltaTime;

            if (_elapsedTime <= 0f)
            {
                SwitchState();
            }
        }

        private void InvokeAttack()
        {
            Context.AnimationController.SetLookDirection(CalculateLookDirection());
            TriggerAttackAnimation();
            Context.StartCoroutine(TryToDamageEnemy());
        }

        private IEnumerator TryToDamageEnemy()
        {
            yield return new WaitForSeconds(AttackData.Delay * AttackData.Time);

            Collider2D[] colliders = FindAttackColliders();

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    IEntity enemy = collider.GetComponent<IEntity>();

                    DamageEntity(enemy);
                }
            }
        }

        private Collider2D[] FindAttackColliders()
        {
            Vector2 lookDirection = CalculateLookDirection();
            bool isHorizontal = Mathf.Abs(lookDirection.x) > Mathf.Abs(lookDirection.y);
            Vector2 direction = new Vector2(
                isHorizontal ? (lookDirection.x / Mathf.Abs(lookDirection.x)) : 0f,
                isHorizontal ? 0f : (lookDirection.y / Mathf.Abs(lookDirection.y))
            );
            Vector2 attackPosition = (Vector2) Context.transform.position + direction * 0.4f;
            Collider2D[] colliders = Physics2D.OverlapCapsuleAll(
                attackPosition,
                new Vector2(isHorizontal ? 1.5f : 1f, isHorizontal ? 1f : 1.5f),
                isHorizontal ? CapsuleDirection2D.Horizontal : CapsuleDirection2D.Vertical,
                0f
            );

            return colliders;
        }

        private void DamageEntity(IEntity enemy)
        {
            if (enemy is null)
            {
                return;
            }

            enemy.Damage(AttackData.Damage);
        }
    }
}
