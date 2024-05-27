using Assets.Scripts.Models;
using Assets.Scripts.StateMachine.Base;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossStateContext : StateContext
    {
        [field: Header("Context")]
        [field: SerializeField] public Transform Target { get; set; }
        [field: SerializeField] public int Wave { get; set; }
        [field: SerializeField] public int HitPoints { get; set; }
        [field: SerializeField] public bool IsAttackAvailable { get; set; } = true;

        [field: Header("Utils")]
        [field: SerializeField] public bool IsDrawGizmos { get; set; }

        [field: Header("Dependencies")]
        [field: SerializeField] public Collider2D Collider { get; set; }
        [field: SerializeField] public AIPath AIPath { get; set; }
        [field: SerializeField] public AIDestinationSetter AIDestinationSetter { get; set; }
        [field: SerializeField] public Seeker Seeker { get; set; }
        [field: SerializeField] public AnimationController AnimationController { get; set; }
        [field: SerializeField] public GameObject DynamitePrefab { get; set; }

        [field: Header("Settings")]
        [field: SerializeField] public float DeadDelay { get; set; }
        [field: SerializeField] public Vector2 OriginPosition { get; set; }
        [field: SerializeField] public float StartAggressionRadius { get; set; }
        [field: SerializeField] public float FinishAggressionRadius { get; set; }
        [field: SerializeField] public int MaximalHitPoints { get; set; }
        [field: SerializeField] public AttackData AttackData { get; set; }
        [field: SerializeField] public float FirstWaveDynamiteDuration { get; set; }
        [field: SerializeField] public float SecondWaveDynamiteDuration { get; set; }

        [field: Header("Aggressive Attack Settings")]
        [field: SerializeField] public AttackData AggressiveAttackData { get; set; }

        [field: Header("Events")]
        [field: SerializeField] public UnityEvent OnBossFightStarted { get; set; } = new UnityEvent();
        [field: SerializeField] public UnityEvent OnBossFightFinished { get; set; } = new UnityEvent();
        [field: SerializeField] public UnityEvent OnBossDied { get; set; } = new UnityEvent();
    }
}
