using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameStartMenu : MonoBehaviour
{
    // public GameObject weaponSelectionPanel;
    // public GameObject rangeSelectionPanel;
    // public GameObject mainMenuPanel;

    [Header("Buttons")]
    public Button startButton;
    public Slider rangeSlider;
    public TMP_Dropdown leftWeaponDropdown;
    public TMP_Dropdown rightWeaponDropdown;
    public GameObject rangeTitle;
    // public Button weaponsButton;
    // public Button rangeButton;
    // public Button aboutButton;
    // public Button quitButton;

    void Start()
    {
        // Button Listeners
        // startButton.onClick.AddListener(StartGame);
        // quitButton.onClick.AddListener(QuitGame);

        // // Placeholder listeners for the other buttons
        // weaponsButton.onClick.AddListener(OpenWeaponsMenu);
        // rangeButton.onClick.AddListener(OpenRangeMenu);
        // aboutButton.onClick.AddListener(OpenAboutMenu);
        VariableHolder.range = 60;
        VariableHolder.left_weapon = 0;
        VariableHolder.right_weapon = 0;
    }

    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene("GameScene");
    }
    public void ConfirmRangeSelection()
    {
        VariableHolder.range = (int)rangeSlider.value*30 + 30; 
        rangeTitle.GetComponent<TextMeshProUGUI>().text = "" +  VariableHolder.range;
    }
    public void ConfirmLeftWeapon()
    {
        VariableHolder.left_weapon = (int)leftWeaponDropdown.value;
    }
        public void ConfirmRightWeapon(string input)
    {
        VariableHolder.right_weapon = (int)rightWeaponDropdown.value;
    }

//     public void QuitGame()
//     {
//         Debug.Log("Quitting the game...");
//         Application.Quit();
//     }

//     // Placeholder methods for the other buttons
//     public void OpenWeaponsMenu()
//     {
//           Debug.Log("Opening weapon selection...");
//         mainMenuPanel.SetActive(false);
//     weaponSelectionPanel.SetActive(true);
// }

//     public void OpenRangeMenu()
//    {
//     Debug.Log("Opening range selection...");
//     mainMenuPanel.SetActive(false);
//     rangeSelectionPanel.SetActive(true);
// }
// public void ReturnToMainMenu()
// {
//     weaponSelectionPanel.SetActive(false);
//     rangeSelectionPanel.SetActive(false);
//     mainMenuPanel.SetActive(true);
// }

//     public void OpenAboutMenu()
//     {
//         Debug.Log("About button clicked. Functionality not implemented yet.");
//     }
}