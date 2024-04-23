using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStartMenu : MonoBehaviour
{
    public GameObject weaponSelectionPanel;
    public GameObject rangeSelectionPanel;
    public GameObject mainMenuPanel;

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
          Debug.Log("Opening weapon selection...");
        mainMenuPanel.SetActive(false);
    weaponSelectionPanel.SetActive(true);
}

    public void OpenRangeMenu()
   {
    Debug.Log("Opening range selection...");
    mainMenuPanel.SetActive(false);
    rangeSelectionPanel.SetActive(true);
}
public void ReturnToMainMenu()
{
    weaponSelectionPanel.SetActive(false);
    rangeSelectionPanel.SetActive(false);
    mainMenuPanel.SetActive(true);
}

    public void OpenAboutMenu()
    {
        Debug.Log("About button clicked. Functionality not implemented yet.");
    }
}