using Assets.Scripts.Models.Enums;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private BetweenSceneData _betweenSceneData;
        [SerializeField] private GameObject _warriorGameObject;
        [SerializeField] private GameObject _archerGameObject;

        private void Start()
        {
            if(_betweenSceneData.SlotData.PlayerClass == PlayerClassEnum.Warrior)
            {
                _warriorGameObject.SetActive(true);
                _archerGameObject.SetActive(false);
            }
            else
            {
                _warriorGameObject.SetActive(false);
                _archerGameObject.SetActive(true);
            }
        }
    }
}
