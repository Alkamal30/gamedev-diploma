using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _victoryPanel;
        [SerializeField] private GameObject _skillsPanel;
        [SerializeField] private GameObject _hudPanel;
        [SerializeField] private GameObject _backgroundShadow;
        [SerializeField] private GameObject _bossHealthBar;

        private GameObject _currentPanel;

        public void OpenMenu()
        {
            ChangeCurrentPanel(_menuPanel);
        }

        public void CloseMenu()
        {
            CloseCurrentPanel();
        }

        public void OpenLosePanel()
        {
            ChangeCurrentPanel(_losePanel);
        }

        public void OpenVictoryPanel()
        {
            ChangeCurrentPanel(_victoryPanel);
        }

        public void OpenSkillsPanel()
        {
            ChangeCurrentPanel(_skillsPanel);
        }

        public void CloseSkillsPanel()
        {
            CloseCurrentPanel();
        }

        public void ShowBossHealthBar()
        {
            _bossHealthBar.SetActive(true);
        }

        public void HideBossHealthBar()
        {
            _bossHealthBar.SetActive(false);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene("MainScene");
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
            else if (Input.GetKeyDown(KeyCode.I))
            {
                if (_currentPanel != null)
                {
                    CloseCurrentPanel();
                }
                else
                {
                    ChangeCurrentPanel(_skillsPanel);
                }
            }
        }

        private void ChangeCurrentPanel(GameObject newPanel)
        {
            _hudPanel?.SetActive(false);
            _currentPanel?.SetActive(false);
            _currentPanel = newPanel;
            _currentPanel?.SetActive(true);

            if(newPanel != null)
            {
                ShowBackgroundShadow();
            }
        }

        private void CloseCurrentPanel()
        {
            _hudPanel?.SetActive(true);
            _currentPanel?.SetActive(false);
            _currentPanel = null;
            HideBackgroundShadow();
        }

        private void ShowBackgroundShadow()
        {
            _backgroundShadow?.SetActive(true);
        }

        private void HideBackgroundShadow()
        {
            _backgroundShadow?.SetActive(false);
        }
    }
}
