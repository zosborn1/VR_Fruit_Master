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

    /**[Header("Weapon Selection UI")]
    public GameObject weaponSelectionMenu;
    public Dropdown leftHandDropdown;
    public Dropdown rightHandDropdown;
    public Button weaponBackButton;**/

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

        // Weapon Selection Button Listeners
        //weaponBackButton.onClick.AddListener(HideWeaponSelectionMenu);

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
        //weaponSelectionMenu.SetActive(false);
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

    void ShowWeaponSelectionMenu()
    {
        HideAll();
        //weaponSelectionMenu.SetActive(true);
    }

    void HideWeaponSelectionMenu()
    {
        //weaponSelectionMenu.SetActive(false);
        EnableMainMenu(); // Return to main menu after hiding weapon selection menu
    }
}
