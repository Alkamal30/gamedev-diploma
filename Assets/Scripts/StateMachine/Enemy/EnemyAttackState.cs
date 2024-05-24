using Assets.Scripts.Abstraction;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Enemy
{
    public class EnemyAttackState : BaseEnemyState
    {
        public EnemyAttackState(IStateSwitcher<EnemyStateContext> stateSwitcher, EnemyStateContext context)
            : base(stateSwitcher, context)
        {
        }

        public override void Start()
        {
            Context.AnimationController.TriggerAttack();
            Context.StartCoroutine(TryToDamageEnemy());
            Context.StartCoroutine(FinishAttackState());
        }

        public override void Stop()
        {
            Context.IsAttackAvailable = false;
            Context.StartCoroutine(MakeAttackAvailable());
        }

        public override void Update()
        {
            if (Context.Target == null)
            {
                StateSwitcher.SwitchState<FollowToOriginEnemyState>();
                return;
            }

            Context.AnimationController.SetLookDirection(CalculateLookDirection());
        }

        private IEnumerator TryToDamageEnemy()
        {
            if (Context.Target != null)
            {
                yield return new WaitForSeconds(Context.AttackData.Delay * Context.AttackData.Time);

                Collider2D[] colliders = FindAttackColliders();

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Player"))
                    {
                        IEntity enemy = collider.GetComponent<IEntity>();

                        DamageEntity(enemy);
                    }
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

            enemy.Damage(Context.AttackData.Damage);
        }

        private IEnumerator FinishAttackState()
        {
            yield return new WaitForSeconds(Context.AttackData.Delay * Context.AttackData.Time);

            if(Context.Target == null)
            {
                StateSwitcher.SwitchState<FollowToOriginEnemyState>();
            }
            else
            {
                StateSwitcher.SwitchState<FollowToTargetEnemyState>();
            }
        }

        private IEnumerator MakeAttackAvailable()
        {
            yield return new WaitForSeconds(Context.AttackData.BetweenAttackDelay);

            Context.IsAttackAvailable = true;
        }

        private Vector2 CalculateLookDirection()
        {
            return (Context.Target.position - Context.transform.position).normalized;
        }
    }
}
