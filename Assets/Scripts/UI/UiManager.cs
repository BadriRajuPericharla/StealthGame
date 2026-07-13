using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum gameMode
{
    none,
    easy,
    practice,
    hard
}
public class UiManager : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private CameraMovement cameraMovement;
    [SerializeField]private PlayerInteraction playerInteraction;
    [SerializeField]private InputManager inputManager;
    [SerializeField]private PlayerDetection[] playerDetection;
    [SerializeField]private GameObject mainMenuPanel;
    [SerializeField]private GameObject gameOverPanel;
    [SerializeField]private GameObject gameCompletePanel;
    [SerializeField]private GameObject levelsPanel;
    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private GameObject mobileControlsPanel;
    [SerializeField]private GameObject aboutPanel;
    [SerializeField]private GameObject settingsPanel;
    [SerializeField]private GameObject sensitivityPanel;
    [SerializeField]private GameObject audioPanel;
    [SerializeField]private GameObject windowsControlsPanel;
    [SerializeField]private GameObject pausePanel;
    [SerializeField]private GameObject countDownPanel;
    [SerializeField]private Button audioButton;
    [SerializeField]private Button sensitivityButton;
    [SerializeField]private Button settingsIconButton;
    [SerializeField]private Button pauseIconButtton;
    [SerializeField]private Button settingsButton;
    [SerializeField]private Button aboutButton;
    [SerializeField]private Button backButton;
    [SerializeField]private Button playButton;
    [SerializeField]private Button exitButton;
    [SerializeField]private Button[] redirectExitButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button retryButton;
    [SerializeField]private Button inventoryButton;
    [SerializeField]private Button practiceButton;
    [SerializeField]private Button easyButton;
    [SerializeField]private Button hardButton;
    [SerializeField]private Button attackButton;
    [SerializeField]private Button claim;
    [SerializeField]private Button doorOpen;
    [SerializeField]private Button resumeButton;
    [SerializeField]private GameObject doorOpenButton;
    [SerializeField]private GameObject claimButton;
    [SerializeField]private TextMeshProUGUI countDownText;
    [SerializeField]private EnemyPatrol[] enemyPatrol;
    [SerializeField]private RandomPatrol[] randomPatrols;
    [SerializeField]private GameObject[] doorKeys;
    public static gameMode currentMode = gameMode.none;
    bool isInventoryOpen=false;
    bool isWindowsControlsOpen=true;
    bool isPause=false;
    public static UiManager Instance;
    public static bool isRetry=false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (!isRetry)
        {
            mainMenuPanel.SetActive(true);
            
            Time.timeScale=0f;
            
            playerAttack.enabled=false;
            cameraMovement.enabled=false;
            playerInteraction.enabled=false;
            playButton.onClick.AddListener(PlayButton);
            restartButton.onClick.AddListener(RestartButton);
            retryButton.onClick.AddListener(RetryButton);
            inventoryButton.onClick.AddListener(ShowInventory);
            practiceButton.onClick.AddListener(PracticeButton);
            easyButton.onClick.AddListener(EasyButton);
            hardButton.onClick.AddListener(HardButton);
            attackButton.onClick.AddListener(inputManager.mobileAttack);
            claim.onClick.AddListener(inputManager.mobileInteract);
            doorOpen.onClick.AddListener(inputManager.DoorOpen);
            aboutButton.onClick.AddListener(ShowAboutPanel);
            backButton.onClick.AddListener(CloseSetiingsPanel);
            settingsIconButton.onClick.AddListener(ShowSettingsPanel);
            sensitivityButton.onClick.AddListener(ShowSensitivityPanel);
            audioButton.onClick.AddListener(ShowAudioPanel);
            settingsButton.onClick.AddListener(ShowSettingsPanel);
            resumeButton.onClick.AddListener(ResumeButton);
            exitButton.onClick.AddListener(ExitButton);
            pauseIconButtton.onClick.AddListener(ShowPausePanel);
            foreach (Button button in redirectExitButton)
            {
                button.onClick.AddListener(RestartButton);
            }
        }
        else
        {
            playButton.onClick.AddListener(PlayButton);
            restartButton.onClick.AddListener(RestartButton);
            retryButton.onClick.AddListener(RetryButton);
            inventoryButton.onClick.AddListener(ShowInventory);
            practiceButton.onClick.AddListener(PracticeButton);
            easyButton.onClick.AddListener(EasyButton);
            hardButton.onClick.AddListener(HardButton);
            attackButton.onClick.AddListener(inputManager.mobileAttack);
            claim.onClick.AddListener(inputManager.mobileInteract);
            doorOpen.onClick.AddListener(inputManager.DoorOpen);
            aboutButton.onClick.AddListener(ShowAboutPanel);
            backButton.onClick.AddListener(CloseSetiingsPanel);
            settingsIconButton.onClick.AddListener(ShowSettingsPanel);
            sensitivityButton.onClick.AddListener(ShowSensitivityPanel);
            audioButton.onClick.AddListener(ShowAudioPanel);
            settingsButton.onClick.AddListener(ShowSettingsPanel);
            resumeButton.onClick.AddListener(ResumeButton);
            exitButton.onClick.AddListener(ExitButton);
            pauseIconButtton.onClick.AddListener(ShowPausePanel);
            foreach (Button button in redirectExitButton)
            {
                button.onClick.AddListener(RestartButton);
            }
            switch (currentMode)
            {
                case gameMode.practice:
                    PracticeButton();
                    break;
                case gameMode.easy:
                    EasyButton();
                    break;
                case gameMode.hard:
                    HardButton();
                    break;
                
            }
        }
        
    }
    public void ShowGameOver()
    {
        DisableScripts();
        gameOverPanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void ShowGameComplete()
    {
        
        DisableScripts();
        gameCompletePanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void PlayButton()
    {
        AudioManager.instance.PlayButtonClick();
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);  
    }
    public void ExitButton()
    {
        AudioManager.instance.PlayButtonClick();
        Application.Quit();
    }
    public void RestartButton()
    {
        AudioManager.instance.PlayButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RetryButton()
    {
        AudioManager.instance.PlayButtonClick();
        isRetry=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState=CursorLockMode.Locked;
    }
    public void ShowInventory()
    {
        isInventoryOpen=!isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }
    public void ShowLevelsPanel()
    {
        AudioManager.instance.PlayButtonClick();
        levelsPanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void PracticeButton()
    {
        isPause=true;
        currentMode=gameMode.practice;
        AudioManager.instance.PlayButtonClick();
        if (Application.isMobilePlatform)
        {
            ShowMobileControls();
        }
        levelsPanel.SetActive(false);
        for(int i=0; i < enemyPatrol.Length; i++)
        {
            enemyPatrol[i].gameObject.SetActive(false);
        }
        for(int j = 0; j < randomPatrols.Length; j++)
        {
            randomPatrols[j].gameObject.SetActive(false);
        }
        for(int k = 0; k < doorKeys.Length; k++)
        {
            doorKeys[k].gameObject.SetActive(true);
        }
        if (Application.isMobilePlatform)
        {
            Cursor.lockState=CursorLockMode.None;
        }
        else
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
        EnableScripts();
        
        

    }
    public void EasyButton()
    {
        isPause=true;
        currentMode=gameMode.easy;
        AudioManager.instance.PlayButtonClick();
        if (Application.isMobilePlatform)
        {
            ShowMobileControls();
        }
        levelsPanel.SetActive(false);
        if (Application.isMobilePlatform)
        {
            Cursor.lockState=CursorLockMode.None;
        }
        else
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
        Time.timeScale=1f;
        for(int j = 0; j < randomPatrols.Length; j++)
        {
            randomPatrols[j].gameObject.SetActive(false);
        }
        EnableScripts();
    }
    public void HardButton()
    {
        isPause=true;
        currentMode=gameMode.hard;
        AudioManager.instance.PlayButtonClick();
        if (Application.isMobilePlatform)
        {
            ShowMobileControls();
        }
        if (Application.isMobilePlatform)
        {
            Cursor.lockState=CursorLockMode.None;
        }
        else
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
        levelsPanel.SetActive(false);
        Time.timeScale=1f;
        EnableScripts();
    }
    public void ShowMobileControls()
    {
        mobileControlsPanel.SetActive(true);
    }
    public void CloseMobileControls()
    {
        mobileControlsPanel.SetActive(false);
    }
    public void ShowClaimButton()
    {
        claimButton.SetActive(true);
    }
    public void CloseCliamButton()
    {
        claimButton.SetActive(false);
    }
    public void ShowDoorOpenButton()
    {
        doorOpenButton.SetActive(true);
    }
    public void CloseDoorOpenButton()
    {
        doorOpenButton.SetActive(false);
    }
    public void ShowAboutPanel()
    {
        isPause=false;
        AudioManager.instance.PlayButtonClick();
        aboutPanel.SetActive(true);
        audioPanel.SetActive(false);
        sensitivityPanel.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        isPause=false;
        AudioManager.instance.PlayButtonClick();
        DisableScripts();
        if (!Application.isMobilePlatform)
        {
            Cursor.lockState=CursorLockMode.None;
        }
        settingsPanel.SetActive(true);
        Time.timeScale=0f;
    }
    public void CloseSetiingsPanel()
    {
        isPause=true;
        AudioManager.instance.PlayButtonClick();
        settingsPanel.SetActive(false);
        EnableScripts();
        Time.timeScale=1f;
    }
    public void ShowAudioPanel()
    {
        isPause=false;
        AudioManager.instance.PlayButtonClick();
        audioPanel.SetActive(true);
        sensitivityPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }
    public void ShowWindowsControls()
    {
        if (!Application.isMobilePlatform)
        {
            isWindowsControlsOpen=!isWindowsControlsOpen;
            windowsControlsPanel.SetActive(isWindowsControlsOpen);
        }
        else
        {
            windowsControlsPanel.SetActive(false);
        }
        
    }
    public void ShowSensitivityPanel()
    {
        isPause=false;
        AudioManager.instance.PlayButtonClick();
        audioPanel.SetActive(false);
        sensitivityPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }
    public void EnableScripts()
    {
        playerMovement.enabled=true;
        playerAttack.enabled=true;
        Time.timeScale=1f;
        foreach(PlayerDetection enemy in playerDetection)
        {
            enemy.enabled=true;
        }
        cameraMovement.enabled=true;
        playerInteraction.enabled=true;
    }
    public void DisableScripts()
    {
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        playerInteraction.enabled=false;
        playerMovement.enabled=false;
        foreach(PlayerDetection enemy in playerDetection)
        {
            if (enemy != null)
            {
                enemy.enabled=false;
            }
        }
    }
    public void ShowPausePanel()
    {
        DisableScripts();
        pausePanel.SetActive(true);
        Time.timeScale=0f;
        if (!Application.isMobilePlatform)
        {
            Cursor.lockState=CursorLockMode.None;
        }
    }
    public void ResumeButton()
    {
        isPause=false;
        pausePanel.SetActive(false);
        Time.timeScale=1f;
        StartCoroutine(CountDown());
        
    }
    void Update()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ShowInventory();   
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ShowSettingsPanel();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                ShowWindowsControls();
            }
            if (Input.GetKeyDown(KeyCode.Escape)&& isPause)
            {
                ShowPausePanel();
            }
        }
        
    }
    IEnumerator CountDown()
    {
        countDownPanel.SetActive(true);
        countDownText.text="3";
        yield return new WaitForSeconds(1);
        countDownText.text="2";
        yield return new WaitForSeconds(1);
        countDownText.text="1";
        yield return new WaitForSeconds(1);
        countDownPanel.SetActive(false);
        isPause=true;
        EnableScripts();
    }
}
