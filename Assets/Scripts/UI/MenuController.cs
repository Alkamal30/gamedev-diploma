using Assets.Scripts;
using Assets.Scripts.Models.Enums;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _chooseCharacterPanel;
    [SerializeField] private GameObject _createCharacterPanel;
    [SerializeField] private GameObject _overviewCharacterPanel;

    [Header("Settings")]
    [SerializeField] private GameObject _initialPanel;

    [Header("Slots Settings")]
    [SerializeField] private GameObject[] _slotButtons;
    [SerializeField] private TMP_InputField _playerNameInput;
    [SerializeField] private TMP_InputField _overviewPlayerNameInput;
    [SerializeField] private BetweenSceneData _betweenSceneData;

    [Header("Ribbons Settings")]
    [SerializeField] private float _xOffset;
    [SerializeField] private RectTransform _chooseWarriorRibbon;
    [SerializeField] private RectTransform _chooseArcherRibbon;
    [SerializeField] private Animator _chooserAnimator;
    [SerializeField] private Animator _overviewChooserAnimator;
    [SerializeField] private AnimatorController _chooseWarriorAnimatorController;
    [SerializeField] private AnimatorController _chooseArcherAnimatorController;

    private GameObject _currentPanel;
    private int? _currentSlot;
    private PlayerClassEnum _currentPlayerClass;

    #region ButtonEventHandlers

    public void ShowMainMenuPanel()
    {
        ChangeCurrentPanel(_mainMenuPanel);
    }

    public void ShowChooseCharacterPanel()
    {
        _currentSlot = null;

        for (int i = 0; i < _slotButtons.Length; i++)
        {
            GameObject button = _slotButtons[i];

            if (DataStorage.IsSlotDataExists(i))
            {
                button.transform.Find("DigitIcon").gameObject.SetActive(true);
                button.transform.Find("PlusIcon").gameObject.SetActive(false);
            }
            else
            {
                button.transform.Find("DigitIcon").gameObject.SetActive(false);
                button.transform.Find("PlusIcon").gameObject.SetActive(true);
            }
        }

        ChangeCurrentPanel(_chooseCharacterPanel);
    }

    public async void SelectCharacterSlot(int slotNumber)
    {
        _currentSlot = slotNumber;

        if (DataStorage.IsSlotDataExists(slotNumber))
        {
            await ShowOverviewCharacterPanel();
        }
        else
        {
            ShowCreateCharacterPanel();
        }
    }

    public async void PlayGame()
    {
        SlotData data = await DataStorage.LoadSlotDataAsync(_currentSlot.Value);
        _betweenSceneData.SlotData = data;

        SceneManager.LoadScene("MainScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public async void CreateCharacter()
    {
        string playerName = _playerNameInput.text.Trim();

        if (!_currentSlot.HasValue || string.IsNullOrEmpty(playerName))
        {
            return;
        }

        SlotData data = new SlotData
        {
            SlotId = _currentSlot.Value,
            PlayerClass = _currentPlayerClass,
            PlayerName = playerName,
            MaximalHealthPoints = 3,
            MaximalStaminaPoints = 2f,
            HitPoints = 3,
        };

        await DataStorage.SaveSlotDataAsync(data);

        await ShowOverviewCharacterPanel();
    }

    public void SelectWarrior()
    {
        SetAnchoredPositionX(_chooseArcherRibbon, _xOffset);
        SetAnchoredPositionX(_chooseWarriorRibbon, 0f);
        _currentPlayerClass = PlayerClassEnum.Warrior;
        _chooserAnimator.runtimeAnimatorController = _chooseWarriorAnimatorController;
    }

    public void SelectArcher()
    {
        SetAnchoredPositionX(_chooseWarriorRibbon, _xOffset);
        SetAnchoredPositionX(_chooseArcherRibbon, 0f);
        _currentPlayerClass = PlayerClassEnum.Archer;
        _chooserAnimator.runtimeAnimatorController = _chooseArcherAnimatorController;
    }

    #endregion

    private void Start()
    {
        _currentPanel = _initialPanel;
        _currentPlayerClass = PlayerClassEnum.Warrior;
    }

    private async Task ShowOverviewCharacterPanel()
    {
        SlotData data = await DataStorage.LoadSlotDataAsync(_currentSlot.Value);
        if (data.PlayerClass == PlayerClassEnum.Archer)
        {
            _overviewChooserAnimator.runtimeAnimatorController = _chooseArcherAnimatorController;
        }
        else
        {
            _overviewChooserAnimator.runtimeAnimatorController = _chooseWarriorAnimatorController;
        }
        _overviewPlayerNameInput.text = data.PlayerName;

        ChangeCurrentPanel(_overviewCharacterPanel);
    }

    private void ShowCreateCharacterPanel()
    {
        ChangeCurrentPanel(_createCharacterPanel);
    }

    private void ChangeCurrentPanel(GameObject newPanel)
    {
        _currentPanel.SetActive(false);
        _currentPanel = newPanel;
        _currentPanel.SetActive(true);
    }

    private void SetAnchoredPositionX(RectTransform transform, float value)
    {
        Vector3 newPosition = transform.anchoredPosition;
        newPosition.x = value;
        transform.anchoredPosition = newPosition;
    }
}
