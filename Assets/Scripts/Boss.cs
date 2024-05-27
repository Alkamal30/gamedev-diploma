using Assets.Scripts.Abstraction;
using Assets.Scripts.StateMachine.Boss;
using UnityEngine;

namespace Assets.Scripts
{
    public class Boss : MonoBehaviour, IEntity
    {
        [SerializeField] private BossStateContext _context;
        [SerializeField] private BossStateBehaviour _stateBehaviour;
        [SerializeField] private DamageAnimation _damageAnimation;

        public void Damage(int value)
        {
            if (_context.Wave == 0)
            {
                return;
            }

            _context.HitPoints -= value;
            _damageAnimation.Play();

            if (_context.HitPoints <= 0f)
            {
                Die();
            }
        }

        private void Start()
        {
            _context.HitPoints = _context.MaximalHitPoints;
        }

        private void Die()
        {
            _stateBehaviour.Dead();
        }
    }
}
