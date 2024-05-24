using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AttackData
    {
        [field: SerializeField]
        public int Damage { get; private set; }
        
        [field: SerializeField]
        public float Time { get; private set; }
        
        [field: SerializeField]
        [field: Range(0f, 1f)]
        public float Delay { get; private set; }

        [field: SerializeField]
        public float BetweenAttackDelay { get; set; }
    }
}
