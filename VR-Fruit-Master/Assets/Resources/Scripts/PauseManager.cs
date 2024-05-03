using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit; // Import XR Interaction Toolkit for XR controller handling
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayersControls controls;
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button mainMenuButton;

    private bool isPaused = false;
    private XRController leftController; // Reference to the left XR controller

    void Awake()
    {
        controls = new PlayersControls();
        controls.Enable(); // Enable the PlayerControls

        controls.GamePause.Pause.performed += ctx => TogglePause(); // Subscribe to the pause action performed event

        // Find the left XR Controller component attached to this GameObject
        leftController = GetComponentInChildren<XRController>();

        // Disable pause menu at start
        pauseMenu.SetActive(false);

        // Add onClick listeners for buttons
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(MainMenu);
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
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
