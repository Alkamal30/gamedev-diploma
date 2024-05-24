using Assets.Scripts.Abstraction;
using Assets.Scripts.StateMachine.Enemy;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity, IAggressiveEntity
{
    [SerializeField] private EnemyStateBehaviour _stateBehaviour;
    [SerializeField] private DamageAnimation _damageAnimation;
    [SerializeField] private int _initialHitPoints;

    private int _hitPoints;

    public int HitPoints => _hitPoints;


    private void Start()
    {
        _hitPoints = _initialHitPoints;
        SetEnemyTag();
    }

    public void Damage(int value)
    {
        _hitPoints -= value;
        _damageAnimation.Play();

        if(_hitPoints <= 0f)
        {
            Die();
        }
    }

    public void DamageWithAggression(IEntity source, int value)
    {
        Damage(value);

        if(source is MonoBehaviour sourceScript)
        {
            _stateBehaviour.ToAggress(sourceScript.transform);
        }
    }

    private void Die()
    {
        _stateBehaviour.Dead();
    }

    private void SetEnemyTag()
    {
        transform.tag = "Enemy";
    }
}
