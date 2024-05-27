using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void SetMovingFlag(bool value)
    {
        _animator.SetBool("IsMoving", value);
    }

    public void TriggerSingleAttack()
    {
        _animator.SetTrigger("SingleAttack");
    }

    public void TriggerLongAttack()
    {
        _animator.SetTrigger("LongAttack");
    }

    public void TriggerStartAttack()
    {
        _animator.SetTrigger("StartAttack");
    }

    public void TriggerAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void TriggerDead()
    {
        _animator.SetTrigger("Dead");
    }

    public void SetMovementDirection(Vector2 direction)
    {
        direction = direction.normalized * 10f;

        _animator.SetFloat("MovementDirectionX", direction.x);
    }

    public void SetLookDirection(Vector2 direction)
    {
        direction = direction.normalized * 10f;

        _animator.SetFloat("LookDirectionX", direction.x);
        _animator.SetFloat("LookDirectionY", direction.y);
    }
}
