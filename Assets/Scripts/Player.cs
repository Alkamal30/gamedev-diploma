using Assets.Scripts.Abstraction;
using Assets.Scripts.StateMachine.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour, IEntity
    {
        [SerializeField] private PlayerStateContext _context;
        [SerializeField] private BasePlayerStateBehaviour _stateBehaviour;
        [SerializeField] private DamageAnimation _damageAnimation;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _staminaBar;
        [SerializeField] private Transform _goldItemsParent;
        [SerializeField] private GameObject _goldItemPrefab;

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

        public void RestoreHealth()
        {
            _context.HitPoints = _context.MaximalHitPoints;
        }

        public void IncreaseGoldCount()
        {
            if(!gameObject.activeSelf)
            {
                return;
            }

            _context.GoldCount++;

            InstantiateGold();
        }

        public void InstantiateGold()
        {
            Instantiate(_goldItemPrefab, _goldItemsParent);
        }

        public void UpHealth()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }

            if(_context.GoldCount > 0)
            {
                _context.MaximalHitPoints++;
                ReduceGoldCount();
            }
        }

        public void UpStamina()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }

            if (_context.GoldCount > 0)
            {
                _context.MaximalStaminaPoints++;
                ReduceGoldCount();
            }
        }

        private void ReduceGoldCount()
        {
            if(!gameObject.activeSelf)
            {
                return;
            }

            _context.GoldCount--;

            if(_goldItemsParent.childCount > 0)
            {
                Destroy(_goldItemsParent.GetChild(0).gameObject);
            }
        }

        private void Start()
        {
            _context.StaminaPoints = _context.MaximalStaminaPoints;

            for (int i = 0; i < _context.GoldCount; i++)
            {
                InstantiateGold();
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _stateBehaviour.Attack();
            }

            _healthBar.fillAmount = (float) _context.HitPoints / _context.MaximalHitPoints;
            _staminaBar.fillAmount = _context.StaminaPoints / _context.MaximalStaminaPoints;
        }

        private void Die()
        {
            AudioController.Instance.PlayDeathClip();
            _stateBehaviour.Dead();
        }
    }
}