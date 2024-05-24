using UnityEngine;

namespace Assets.Scripts.Abstraction
{
    public interface IWeapon
    {
        float AttackSpeed { get; }

        float Damage { get; }

        WeaponKind Kind { get; }
    }
}
