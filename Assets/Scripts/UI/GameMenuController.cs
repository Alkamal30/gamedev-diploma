using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;

        private GameObject _currentPanel;

        public void OpenMenu()
        {
            ChangeCurrentPanel(_menuPanel);
        }

        public void CloseMenu()
        {
            CloseCurrentPanel();
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }

        private void Start()
        {
            _currentPanel = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(_currentPanel != null)
                {
                    CloseCurrentPanel();
                }
                else
                {
                    ChangeCurrentPanel(_menuPanel);
                }
            }
        }

        private void ChangeCurrentPanel(GameObject newPanel)
        {
            _currentPanel?.SetActive(false);
            _currentPanel = newPanel;
            _currentPanel?.SetActive(true);
        }

        private void CloseCurrentPanel()
        {
            _currentPanel?.SetActive(false);
            _currentPanel = null;
        }
    }
}
