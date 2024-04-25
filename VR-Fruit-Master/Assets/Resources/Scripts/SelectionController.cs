using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    public Dropdown leftWeaponDropdown;
    public Dropdown rightWeaponDropdown;
    public Slider rangeSlider;
    public GameObject mainMenuPanel;
    public GameObject weaponSelectionPanel;
    public GameObject rangeSelectionPanel;
    public Button weaponBackButton;
    public Button rangeBackButton;

    //private VariableHolder variableHolder;

     public void Start()
    {
        // GameObject variableHolderObject = GameObject.FindGameObjectWithTag("VariableHolder");
        // if (variableHolderObject != null)
        // {
        //     variableHolder = variableHolderObject.GetComponent<VariableHolder>();
        // }
        // else
        // {
        //     Debug.LogError("VariableHolder GameObject not found!");
        // }
        // VariableHolder.range = 60;
        // VariableHolder.left_weapon = "";
        // VariableHolder.right_weapon = "";
        //SetupRangeSlider();
        //SetupBackButtons();
    }
    // private void SetupRangeSlider()
    // {
    //     rangeSlider.minValue = 60;
    //     rangeSlider.maxValue = 360;
    //     rangeSlider.wholeNumbers = true;
    //     rangeSlider.value = 60;
    // }

//   private void SetupBackButtons()
//     {
//         //weaponBackButton.onClick.AddListener(ReturnToMainMenu);
//         //rangeBackButton.onClick.AddListener(ReturnToMainMenu);
//     }
//     public void ConfirmWeaponSelection()
//     {
//         if (variableHolder != null)
//         {
//             variableHolder.left_weapon = leftWeaponDropdown.options[leftWeaponDropdown.value].text;
//             variableHolder.right_weapon = rightWeaponDropdown.options[rightWeaponDropdown.value].text;
//         }
        
//         ReturnToMainMenu();
//     }
    public void ConfirmRangeSelection()
    {
        VariableHolder.range = (int)rangeSlider.value;
    }
    // public void ConfirmLeftWeapon()
    // {
    //     VariableHolder.left_weapon = leftWeaponDropdown.value;
    // }

//    private void ReturnToMainMenu()
// {
//     Debug.Log("ReturnToMainMenu called");
//     weaponSelectionPanel.SetActive(false);
//     rangeSelectionPanel.SetActive(false);
//     mainMenuPanel.SetActive(true);
// }
}