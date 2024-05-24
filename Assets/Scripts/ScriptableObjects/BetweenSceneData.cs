using Assets.Scripts;
using UnityEngine;

[CreateAssetMenu]
public class BetweenSceneData : ScriptableObject
{
    [SerializeField] private SlotData _slotData;

    public SlotData SlotData
    {
        get { return _slotData; }
        set { _slotData = value; }
    }
}
