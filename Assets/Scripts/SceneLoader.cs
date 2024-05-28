using Assets.Scripts.Models.Enums;
using Assets.Scripts.StateMachine.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private BetweenSceneData _betweenSceneData;
        [SerializeField] private GameObject _warriorGameObject;
        [SerializeField] private GameObject _archerGameObject;
        [SerializeField] private PlayerStateContext _warriorStateContext;
        [SerializeField] private PlayerStateContext _archerStateContext;
        [SerializeField] private GameObject[] _goldItems;

        private void Awake()
        {
            PlayerStateContext stateContext;

            if(_betweenSceneData.SlotData.PlayerClass == PlayerClassEnum.Warrior)
            {
                _warriorGameObject.SetActive(true);
                _archerGameObject.SetActive(false);

                stateContext = _warriorStateContext;
            }
            else
            {
                _warriorGameObject.SetActive(false);
                _archerGameObject.SetActive(true);

                stateContext = _archerStateContext;
            }

            stateContext.MaximalHitPoints = _betweenSceneData.SlotData.MaximalHealthPoints;
            stateContext.MaximalStaminaPoints = _betweenSceneData.SlotData.MaximalStaminaPoints;
            stateContext.HitPoints = _betweenSceneData.SlotData.HitPoints;
            stateContext.GoldCount = _betweenSceneData.SlotData.GoldCount;
        }

        private async void OnDestroy()
        {
            SlotData slotData = _betweenSceneData.SlotData;

            PlayerStateContext stateContext = slotData.PlayerClass == PlayerClassEnum.Warrior
                ? _warriorStateContext : _archerStateContext;

            slotData.MaximalHealthPoints = stateContext.MaximalHitPoints;
            slotData.MaximalStaminaPoints = stateContext.MaximalStaminaPoints;
            slotData.HitPoints = stateContext.HitPoints;
            slotData.GoldCount = stateContext.GoldCount;

            await DataStorage.SaveSlotDataAsync(slotData);
        }
    }
}
