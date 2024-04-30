using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button mainMenuButton;

    private XRController controller;
    private bool isPaused = false;

    void Start()
    {
        // Find the XR Controller component attached to this GameObject
        controller = GetComponentInChildren<XRController>();

        if (controller == null)
        {
            Debug.LogError("XR Controller not found! Make sure it's attached to the same GameObject or its children.");
        }

        // Disable pause menu at start
        pauseMenu.SetActive(false);

        // Add onClick listeners for buttons
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    void Update()
    {
        // Detect Y button press
        if (controller != null && controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool isPressed) && isPressed)
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Pause or unpause time

        // Show/hide pause menu
        pauseMenu.SetActive(isPaused);

        // Log pause state
        if (isPaused)
        {
            Debug.Log("Game Paused");
        }
        else
        {
            Debug.Log("Game Resumed");
        }
    }

    void ResumeGame()
    {
        TogglePause(); // Resume game by toggling pause state
    }

    void MainMenu()
    {
        // Load the start scene
        SceneManager.LoadScene("StartScene");
    }
}
