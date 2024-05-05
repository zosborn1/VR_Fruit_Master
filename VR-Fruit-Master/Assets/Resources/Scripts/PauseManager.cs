using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit; // Import XR Interaction Toolkit for XR controller handling
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayersControls controls;

    private bool isPaused = false;
    private XRController leftController; // Reference to the left XR controller

    void Awake()
    {
        controls = new PlayersControls();
        controls.Enable(); // Enable the PlayerControls

        controls.GamePause.Pause.performed += ctx => TogglePause(); // Subscribe to the pause action performed event
        controls.GamePause.StartScene.performed += ctx => NavigateToStartScene(); // Subscribe to the navigate action performed event

        // Find the left XR Controller component attached to this GameObject
        leftController = GetComponentInChildren<XRController>();
    }

    void Update()
    {
        // Check for Y button press on the left controller
        if (leftController != null && leftController.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool isYPressed) && isYPressed)
        {
            if (isPaused)
            {
                // If game is paused, resume the game
                ResumeGame();
            }
            else
            {
                // If game is not paused, pause the game
                TogglePause();
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Pause or unpause time

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

    void NavigateToStartScene()
    {
        if (isPaused)
        {
            // Load the start scene if game is paused
            SceneManager.LoadScene("StartScene");
        }
    }
}
