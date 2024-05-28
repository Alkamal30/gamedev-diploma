using Assets.Scripts.Models.Enums;
using System;

namespace Assets.Scripts
{
    [Serializable]
    public class SlotData
    {
        public int SlotId;

        public PlayerClassEnum PlayerClass;

        public string PlayerName;

        public int MaximalHealthPoints;

        public float MaximalStaminaPoints;

        public int HitPoints;

        public int GoldCount;
    }
}
