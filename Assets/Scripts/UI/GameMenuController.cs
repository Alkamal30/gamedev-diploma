﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _victoryPanel;
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
        }

        private void ChangeCurrentPanel(GameObject newPanel)
        {
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
