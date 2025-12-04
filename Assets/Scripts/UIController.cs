using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.Collections;
using System.Collections.Generic;

public enum UIPanel
{
    Menu,
    Gameplay,
    Win,
    Lose,
    Pause,
    Settings
}
public class UIController : BaseBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField,ReadOnly] private UIPanel currentPanel;
    public Dictionary<UIPanel, GameObject> panelDictionary = new Dictionary<UIPanel, GameObject>();

    [Header("Menu Buttons")]
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [Header("Gameplay Buttons")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button shuffleButton;
    [SerializeField] private Button hintButton;

    [Header("Pause Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    [Header("Win Buttons")]
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button backToMenuButton;
    [Header("Lose Buttons")]
    [SerializeField] private Button loseRetryButton;
    [SerializeField] private Button loseBackToMenuButton;

    [Header("Settings Buttons")]
    [SerializeField] private Button settingsCloseButton;
    [SerializeField] private Slider MusicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;


    [Header("Level Selection")]
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private int startLevel = 1;

    protected override void LoadComponents()
    {
        // Auto find panels
        if (menuPanel == null) menuPanel = GameObject.Find("MenuPanel");
        if (gameplayPanel == null) gameplayPanel = GameObject.Find("GameplayPanel");
        if (winPanel == null) winPanel = GameObject.Find("WinPanel");
        if (losePanel == null) losePanel = GameObject.Find("LosePanel");
        if (pausePanel == null) pausePanel = GameObject.Find("PausePanel");
        if (settingsPanel == null) settingsPanel = GameObject.Find("SettingsPanel");
    }

    protected override void Start()
    {
        // initialize dictionary panel
        InitializeDictionary();
        // setup button listeners
        SetupButtonListeners();
        // show menu panel at start
        ShowMenuPanel();

    }

    /// <summary>
    /// Setup các button listeners
    /// </summary>
    private void SetupButtonListeners()
    {
        // Menu buttons
        if (startGameButton != null) startGameButton.onClick.AddListener(OnStartGameClick);
        if (settingsButton != null) settingsButton.onClick.AddListener(OnSettingsClick);
        if (quitButton != null) quitButton.onClick.AddListener(OnQuitClick);

        // Gameplay buttons
        if (pauseButton != null) pauseButton.onClick.AddListener(OnPauseClick);
        if (shuffleButton != null) shuffleButton.onClick.AddListener(OnShuffleClick);
        if (hintButton != null) hintButton.onClick.AddListener(OnHintClick);

        // Pause buttons
        if (resumeButton != null) resumeButton.onClick.AddListener(OnResumeClick);
        if (restartButton != null) restartButton.onClick.AddListener(OnRestartClick);
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(OnMainMenuClick);

        // Win buttons
        if (nextLevelButton != null) nextLevelButton.onClick.AddListener(OnNextLevelClick);
        if (backToMenuButton != null) backToMenuButton.onClick.AddListener(OnBackToMenuClick);
        // Lose buttons
        if (loseRetryButton != null) loseRetryButton.onClick.AddListener(OnRetryClick);
        if (loseBackToMenuButton != null) loseBackToMenuButton.onClick.AddListener(OnBackToMenuClick);

        // Settings buttons
        if (settingsCloseButton != null) settingsCloseButton.onClick.AddListener(OnSettingsCloseClick);
        GetVolumeSettings();
    }

    #region Menu Panel

    private void InitializeDictionary()
    {
        panelDictionary = new Dictionary<UIPanel, GameObject>()
        {
            { UIPanel.Menu, menuPanel },
            { UIPanel.Gameplay, gameplayPanel },
            { UIPanel.Win, winPanel },
            { UIPanel.Lose, losePanel },
            { UIPanel.Pause, pausePanel },
            { UIPanel.Settings, settingsPanel }
        };
    }
    /// <summary>
    /// Show Main Menu Panel
    /// </summary>
   
    public void ShowMenuPanel()
    {
    }

    /// <summary>
    /// Start game button click
    /// </summary>
    private void OnStartGameClick()
    {
    }

    private void OnSettingsClick()
    {
    }



    private void OnQuitClick()
    {
       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    #endregion

    #region Settings Panel

    private void OnSettingsCloseClick()
    {
        
    }
    private void GetVolumeSettings()
    {
        if (MusicVolumeSlider != null)
        {
            float musicVolume = GameSetting.Instance.GetMusicVolume();
            MusicVolumeSlider.value = musicVolume;
            MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }
        if (SFXVolumeSlider != null)
        {
            float sfxVolume = GameSetting.Instance.GetSFXVolume();
            SFXVolumeSlider.value = sfxVolume;
            SFXVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        }
    }
    private void OnMusicVolumeChanged(float value)
    {
        GameSetting.Instance.SetMusicVolume(value);

    }
    private void OnSFXVolumeChanged(float value)
    {
        GameSetting.Instance.SetSFXVolume(value);
    }

    #endregion

    #region Gameplay Panel
    /// <summary>
    /// Pause game
    /// </summary>
    private void OnPauseClick()
    {
        
    }

    /// <summary>
    /// Shuffle board
    /// </summary>
    private void OnShuffleClick()
    {
       
    }

    /// <summary>
    /// Hint - highlight clickable items
    /// </summary>
    private void OnHintClick()
    {
       
    }

    private void HighlightClickableItems()
    {
       
    }
    #endregion

    #region Pause Panel
    private void OnResumeClick()
    {
       
    }

    private void OnRestartClick()
    {
        
    }

    private void OnMainMenuClick()
    {   
       
    }
    #endregion

    #region Win/Lose Panel
    /// <summary>
    /// Hiển thị panel Win
    /// </summary>
    public void ShowWinPanel()
    {
       
    }

    /// <summary>
    /// Hiển thị panel Lose
    /// </summary>
    public void ShowLosePanel()
    {
       
    }

    private void OnNextLevelClick()
    {
       
    }

    private void OnRetryClick()
    {
       
    }

    private void OnBackToMenuClick()
    {
       
    }


    #endregion

    #region Helper Methods
    /// <summary>
    /// Set active một panel, ẩn các panel khác
    /// </summary>
    private void SetActivePanel(UIPanel activePanel)
    {
       if(currentPanel == activePanel) return;
         foreach (var panelPair in panelDictionary)
         {
              if (panelPair.Value != null)
              {
                panelPair.Value.SetActive(panelPair.Key == activePanel);
              }
         }
         currentPanel = activePanel;
    }
    #endregion
}
