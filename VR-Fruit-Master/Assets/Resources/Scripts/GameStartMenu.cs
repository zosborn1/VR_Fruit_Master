using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    [Header("Main Menu UI")]
    public GameObject mainMenu;
    public GameObject weaponsMenu;
    public GameObject rangeMenu;
    public GameObject aboutMenu;


    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button weaponsButton;
    public Button rangeButton;
    public Button aboutButton;
    public Button quitButton;

    void Start()
    {
        // Main Menu Button Listeners
        startButton.onClick.AddListener(StartGame);
        weaponsButton.onClick.AddListener(EnableWeaponsMenu);
        rangeButton.onClick.AddListener(EnableRangeMenu);
        aboutButton.onClick.AddListener(EnableAboutMenu);
        quitButton.onClick.AddListener(QuitGame);

        EnableMainMenu();
    }

    public void StartGame() { 
            Debug.Log("Attempting to start the game...");
            HideAll();
            SceneManager.LoadScene("newRoom");
        }

        public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the game...");
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        weaponsMenu.SetActive(false);
        rangeMenu.SetActive(false);
        aboutMenu.SetActive(false);
    }

    public void EnableMainMenu()
    {
        HideAll();
        mainMenu.SetActive(true);
    }

    public void EnableWeaponsMenu()
    {
HideAll();
        weaponsMenu.SetActive(true);
    }

    public void EnableRangeMenu()
    {
        HideAll();
        rangeMenu.SetActive(true);
    }

    public void EnableAboutMenu()
    {
        HideAll();
        aboutMenu.SetActive(true);
    }

}
