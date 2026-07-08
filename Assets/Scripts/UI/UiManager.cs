using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private CameraMovement cameraMovement;
    [SerializeField]private PlayerInteraction playerInteraction;
    [SerializeField]private PlayerDetection[] playerDetection;
    [SerializeField]private GameObject mainMenuPanel;
    [SerializeField]private GameObject gameOverPanel;
    [SerializeField]private GameObject gameCompletePanel;
    [SerializeField]private GameObject levelsPanel;
    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private Button playButton;
    [SerializeField]private Button[] exitButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button retryButton;
    [SerializeField]private Button inventoryButton;
    [SerializeField]private Button practiceButton;
    [SerializeField]private Button easyButton;
    [SerializeField]private Button hardButton;
    [SerializeField]private EnemyPatrol[] enemyPatrol;
    [SerializeField]private RandomPatrol[] randomPatrols;
    [SerializeField]private GameObject[] doorKeys;
    [SerializeField]private GameObject mobileControlsPanel;
    bool isInventoryOpen=false;
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
            playerMovement.enabled=false;
            Time.timeScale=0f;
            foreach(PlayerDetection enemy in playerDetection)
            {
                enemy.enabled=false;
            }
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
            foreach (Button button in exitButton)
            {
                button.onClick.AddListener(ExitButton);
            }
        }
        else
        {
            mainMenuPanel.SetActive(false);
            playerMovement.enabled=true;
            Time.timeScale=1f;
            foreach(PlayerDetection enemy in playerDetection)
            {
                enemy.enabled=true;
            }
            playerAttack.enabled=true;
            cameraMovement.enabled=true;
            playerInteraction.enabled=true;
            playButton.onClick.AddListener(PlayButton);
            restartButton.onClick.AddListener(RestartButton);
            retryButton.onClick.AddListener(RetryButton);
            inventoryButton.onClick.AddListener(ShowInventory);
            practiceButton.onClick.AddListener(PracticeButton);
            easyButton.onClick.AddListener(EasyButton);
            hardButton.onClick.AddListener(HardButton);
            foreach (Button button in exitButton)
            {
                button.onClick.AddListener(ExitButton);
            }
        }
        
    }
    public void ShowGameOver()
    {
        playerMovement.enabled=false;
        foreach(PlayerDetection enemy in playerDetection)
        {
            if (enemy != null)
            {
               enemy.enabled=false; 
            } 
        }
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        playerInteraction.enabled=false;
        gameOverPanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void ShowGameComplete()
    {
        playerMovement.enabled=false;
        foreach(PlayerDetection enemy in playerDetection)
        {
            if (enemy != null)
            {
                enemy.enabled=false;
            }
        }
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        playerInteraction.enabled=false;
        gameCompletePanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);  
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RetryButton()
    {
         isRetry=true;
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowInventory()
    {
        isInventoryOpen=!isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }
    public void ShowLevelsPanel()
    {
        levelsPanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void PracticeButton()
    {
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
        Cursor.lockState=CursorLockMode.None;
        if (Application.isMobilePlatform)
        {
            mobileControlsPanel.SetActive(true);
        }
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
    public void EasyButton()
    {
        levelsPanel.SetActive(false);
        Cursor.lockState=CursorLockMode.Locked;
        playerMovement.enabled=true;
        playerAttack.enabled=true;
        Time.timeScale=1f;
        for(int j = 0; j < randomPatrols.Length; j++)
        {
            randomPatrols[j].gameObject.SetActive(false);
        }
        foreach(PlayerDetection enemy in playerDetection)
        {
            enemy.enabled=true;
        }
        cameraMovement.enabled=true;
        playerInteraction.enabled=true;
    }
    public void HardButton()
    {
        levelsPanel.SetActive(false);
        Cursor.lockState=CursorLockMode.Locked;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShowInventory();
            
        }
    }
}
