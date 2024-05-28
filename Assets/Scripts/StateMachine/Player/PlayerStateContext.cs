using Assets.Scripts.Models;
using Assets.Scripts.StateMachine.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerStateContext : StateContext
    {
        [field: Header("Context")]
        [field: SerializeField] public int HitPoints { get; set; }
        [field: SerializeField] public float StaminaPoints { get; set; }
        [field: SerializeField] public bool IsAttackAvailable { get; set; } = true;
        [field: SerializeField] public bool IsJerkAvailable { get; set; } = true;
        [field: SerializeField] public int GoldCount { get; set; }

        [field: Header("Dependencies")]
        [field: SerializeField] public Scripts.Player Player { get; set; }
        [field: SerializeField] public AnimationController AnimationController { get; set; }
        [field: SerializeField] public GameObject ArrowPrefab { get; set; }

        [field: Header("Settings")]
        [field: SerializeField] public float DeadDelay { get; set; }
        [field: SerializeField] public int MaximalHitPoints { get; set; }
        [field: SerializeField] public float MovementSpeed { get; set; }
        [field: SerializeField] public float JerkLength { get; set; }
        [field: SerializeField] public float JerkDuration { get; set; }

        [field: Header("Attack Settings")]
        [field: SerializeField] public AttackData SingleAttackData { get; private set; }
        [field: SerializeField] public AttackData LongAttackData { get; private set; }
        [field: SerializeField] public AttackData ArcherAttackData { get; set; }
        [field: SerializeField] public string TargetTag { get; set; }

        [field: Header("Jerk Settings")]
        [field: SerializeField] public float MaximalStaminaPoints { get; set; }
        [field: SerializeField] public float StaminaRegeneration { get; set; }
        [field: SerializeField] public float BetweenJerkDelay { get; set; }

        [field: Header("Events")]
        [field: SerializeField] public UnityEvent OnDied { get; set; } = new UnityEvent();
    }
}
