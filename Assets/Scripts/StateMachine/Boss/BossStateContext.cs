using Assets.Scripts.StateMachine.Base;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossStateContext : StateContext
    {
        [field: Header("Context")]
        [field: SerializeField] public Transform Target { get; set; }
        [field: SerializeField] public int Wave { get; set; }
        [field: SerializeField] public int HitPoints { get; set; }

        [field: Header("Utils")]
        [field: SerializeField] public bool IsDrawGizmos { get; set; }

        [field: Header("Dependencies")]
        [field: SerializeField] public Collider2D Collider { get; set; }
        [field: SerializeField] public AIPath AIPath { get; set; }
        [field: SerializeField] public AIDestinationSetter AIDestinationSetter { get; set; }
        [field: SerializeField] public Seeker Seeker { get; set; }
        [field: SerializeField] public AnimationController AnimationController { get; set; }

        [field: Header("Settings")]
        [field: SerializeField] public float DeadDelay { get; set; }
        [field: SerializeField] public Vector2 OriginPosition { get; set; }
        [field: SerializeField] public float StartAggressionRadius { get; set; }
        [field: SerializeField] public float FinishAggressionRadius { get; set; }
        [field: SerializeField] public int MaximalHitPoints { get; set; }
    }
}
