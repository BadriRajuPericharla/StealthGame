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
    [SerializeField]private KeysClaiming keysClaiming;
    [SerializeField]private PlayerDetection[] playerDetection;
    [SerializeField]private GameObject mainMenuPanel;
    [SerializeField]private GameObject gameOverPanel;
    [SerializeField]private GameObject gameCompletePanel;
    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private Button playButton;
    [SerializeField]private Button[] exitButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button retryButton;
    [SerializeField]private Button inventoryButton;
    int clickCount=0;
    public static UiManager Instance;
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
        mainMenuPanel.SetActive(true);
        playerMovement.enabled=false;
        Time.timeScale=0f;
        foreach(PlayerDetection enemy in playerDetection)
        {
            enemy.enabled=false;
        }
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        keysClaiming.enabled=false;
        playButton.onClick.AddListener(PlayButton);
        restartButton.onClick.AddListener(RestartButton);
        retryButton.onClick.AddListener(RestartButton);
        inventoryButton.onClick.AddListener(ShowInventory);
        foreach (Button button in exitButton)
        {
            button.onClick.AddListener(ExitButton);
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
        keysClaiming.enabled=false;
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
        keysClaiming.enabled=false;
        gameCompletePanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
    }
    public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        playerMovement.enabled=true;
        playerAttack.enabled=true;
        Time.timeScale=1f;
        foreach(PlayerDetection enemy in playerDetection)
        {
            enemy.enabled=true;
        }
        cameraMovement.enabled=true;
        keysClaiming.enabled=true;
        Cursor.lockState=CursorLockMode.Locked;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
    }
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            clickCount++;
            if (clickCount % 2 != 0)
            {
                ShowInventory();
            }
            else
            {
                CloseInventory();
            }
            
        }
    }
}
