using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameStartMenu : MonoBehaviour
{

    [Header("Buttons")]
    public Button startButton;
    public Slider rangeSlider;
    public TMP_Dropdown leftWeaponDropdown;
    public TMP_Dropdown rightWeaponDropdown;
    public GameObject rangeTitle;


    void Start()
    {

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
    public void Quit()
    {
        Application.Quit();
    }

}