using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _swordsman;

    [SerializeField]
    private GameObject _wizard;

    [SerializeField]
    private GameObject _panel;

    public void SelectSwordsman()
    {
        _swordsman.SetActive(true);
        HidePanel();
    }

    public void SelectWizard()
    {
        _wizard.SetActive(true);
        HidePanel();
    }

    private void HidePanel()
    {
        _panel.SetActive(false);
    }
}
