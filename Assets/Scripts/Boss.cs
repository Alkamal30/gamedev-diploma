using Assets.Scripts.Abstraction;
using Assets.Scripts.StateMachine.Boss;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Boss : MonoBehaviour, IEntity
    {
        [SerializeField] private BossStateContext _context;
        [SerializeField] private BossStateBehaviour _stateBehaviour;
        [SerializeField] private DamageAnimation _damageAnimation;
        [SerializeField] private Image _healthBar;

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
            else if( _context.HitPoints <= 8f)
            {
                _context.Wave = 3;
            }
            else if (_context.HitPoints <= 15)
            {
                _context.Wave = 2;
            }
        }

        private void Start()
        {
            _context.HitPoints = _context.MaximalHitPoints;
        }

        private void Update()
        {
            _healthBar.fillAmount = (float) _context.HitPoints / _context.MaximalHitPoints;
        }

        private void Die()
        {
            _stateBehaviour.Dead();
        }
    }
}
