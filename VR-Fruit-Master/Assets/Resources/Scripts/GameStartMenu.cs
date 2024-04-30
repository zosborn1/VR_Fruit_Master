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
    public GameObject highscore;
    public GameObject new_display;
    public GameObject titlecard;

    private float fluctuate = 0.0f;
    private TextMeshProUGUI new_text;

    void Start()
    {
        new_text = new_display.GetComponent<TextMeshProUGUI>();

        if(VariableHolder.highscore > PlayerPrefs.GetInt("highscore", 0)) {
            PlayerPrefs.SetInt("highscore", VariableHolder.highscore);
            new_display.SetActive(true);
        }

        highscore.GetComponent<TextMeshProUGUI>().text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);

        rangeSlider.value = (PlayerPrefs.GetInt("range", 1)-30)/30;
        leftWeaponDropdown.value = PlayerPrefs.GetInt("left_weapon", 0);
        rightWeaponDropdown.value = PlayerPrefs.GetInt("right_weapon", 0);

        VariableHolder.range = (int)rangeSlider.value*30 + 30; 
        VariableHolder.left_weapon = leftWeaponDropdown.value;
        VariableHolder.right_weapon = rightWeaponDropdown.value;
    }

    void Update() {
        fluctuate += Time.deltaTime*0.5f;
        new_display.transform.localScale = new Vector3(1.25f + Mathf.Cos(fluctuate*4.0f)/4.0f, 1.25f + Mathf.Cos(fluctuate*4.0f)/4.0f, 1);

        titlecard.transform.localScale = new Vector3(2.25f + Mathf.Cos(fluctuate)/4.0f, 2.25f + Mathf.Cos(fluctuate)/4.0f, 1);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("range", VariableHolder.range);
        PlayerPrefs.SetInt("left_weapon", VariableHolder.left_weapon);
        PlayerPrefs.SetInt("right_weapon", VariableHolder.right_weapon);

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
        PlayerPrefs.SetInt("range", VariableHolder.range);
        PlayerPrefs.SetInt("left_weapon", VariableHolder.left_weapon);
        PlayerPrefs.SetInt("right_weapon", VariableHolder.right_weapon);

        Application.Quit();
    }

}