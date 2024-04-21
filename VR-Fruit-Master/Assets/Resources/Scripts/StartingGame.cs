using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStartMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button weaponsButton;
    public Button rangeButton;
    public Button aboutButton;
    public Button quitButton;

    void Start()
    {
        // Button Listeners
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

        // Placeholder listeners for the other buttons
        weaponsButton.onClick.AddListener(OpenWeaponsMenu);
        rangeButton.onClick.AddListener(OpenRangeMenu);
        aboutButton.onClick.AddListener(OpenAboutMenu);
    }

    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene("newRoom");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    // Placeholder methods for the other buttons
    public void OpenWeaponsMenu()
    {
        Debug.Log("Weapons button clicked. Functionality not implemented yet.");
    }

    public void OpenRangeMenu()
    {
        Debug.Log("Range button clicked. Functionality not implemented yet.");
    }

    public void OpenAboutMenu()
    {
        Debug.Log("About button clicked. Functionality not implemented yet.");
    }
}