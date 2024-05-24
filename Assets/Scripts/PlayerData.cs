using Assets.Scripts.Abstraction;
using Assets.Scripts.Models;
using Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerData : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public AnimationController AnimationController => _animationController;
        public float MovementSpeed => _movementSpeed;
        public float JerkLength => _jerkLength;
        public float JerkDuration => _jerkDuration;


        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AnimationController _animationController;
        
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jerkLength;
        [SerializeField] private float _jerkDuration;

        [field: SerializeField] public AttackData SingleAttackData { get; private set; }
        [field: SerializeField] public AttackData LongAttackData { get; private set; }
    }
}
