using Assets.Scripts.Abstraction;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/New Weapon")]
    public class Weapon : ScriptableObject, IWeapon
    {
        [SerializeField]
        private float _attackSpeed;

        [SerializeField]
        private float _damage;

        [SerializeField]
        private WeaponKind _weaponKind;

        public float AttackSpeed => _attackSpeed;

        public float Damage => _damage;

        public WeaponKind Kind => _weaponKind;
    }
}
