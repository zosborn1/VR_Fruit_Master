using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
{
    isPaused = !isPaused;
    pauseMenuPanel.SetActive(isPaused);
    
    Debug.Log("TogglePause called. isPaused: " + isPaused);
    Debug.Log("Pause Menu Panel active: " + pauseMenuPanel.activeSelf);

    Time.timeScale = isPaused ? 0f : 1f;
}

void ActivatePauseMenuPanel()
{
    pauseMenuPanel.SetActive(true);
    Debug.Log("Pause Menu Panel active: " + pauseMenuPanel.activeSelf);
}
    public void ResumeGame()
{
    Debug.Log("ResumeGame called.");
    TogglePause();
}

public void GoToMainMenu()
{
    Debug.Log("GoToMainMenu called.");
    Time.timeScale = 1f;
    SceneManager.LoadScene("StartScene");
}
}