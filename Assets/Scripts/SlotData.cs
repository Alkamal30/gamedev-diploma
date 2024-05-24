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
    }
}
