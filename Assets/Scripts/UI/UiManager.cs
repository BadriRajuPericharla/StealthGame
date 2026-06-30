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
    [SerializeField]private GameObject mainMenuPanel;
    [SerializeField]private GameObject gameOverPanel;
    [SerializeField]private GameObject gameCompletePanel;
    [SerializeField]private Button playButton;
    [SerializeField]private Button[] exitButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button retryButton;
    public static UiManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance=this;
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
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        keysClaiming.enabled=false;
        Time.timeScale=0f;
        playButton.onClick.AddListener(PlayButton);
        restartButton.onClick.AddListener(RestartButton);
        retryButton.onClick.AddListener(RestartButton);
        foreach (Button button in exitButton)
        {
            button.onClick.AddListener(ExitButton);
        }
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        playerMovement.enabled=false;
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        keysClaiming.enabled=false;
        Cursor.lockState=CursorLockMode.None;
    }
    public void ShowGameComplete()
    {
        gameCompletePanel.SetActive(true);
        playerMovement.enabled=false;
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        keysClaiming.enabled=false;
        Cursor.lockState=CursorLockMode.None;
    }
    public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        playerMovement.enabled=true;
        playerAttack.enabled=true;
        cameraMovement.enabled=true;
        keysClaiming.enabled=true;
        Cursor.lockState=CursorLockMode.Locked;
        Time.timeScale=1f;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
