using Assets.Scripts.Abstraction;
using Assets.Scripts.StateMachine.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour, IEntity
    {
        [SerializeField] private PlayerStateContext _context;
        [SerializeField] private BasePlayerStateBehaviour _stateBehaviour;
        [SerializeField] private DamageAnimation _damageAnimation;

        public int HitPoints => _context.HitPoints;

        public void Damage(int value)
        {
            _context.HitPoints -= value;
            _damageAnimation.Play();

            if (_context.HitPoints <= 0f)
            {
                Die();
            }
        }

        private void Awake()
        {
            _context.HitPoints = _context.MaximalHitPoints;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _stateBehaviour.Attack();
            }
        }

        private void Die()
        {
            _stateBehaviour.Dead();
        }
    }
}