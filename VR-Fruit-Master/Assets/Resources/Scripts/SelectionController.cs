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

    private VariableHolder variableHolder;

     private void Start()
    {
        GameObject variableHolderObject = GameObject.FindGameObjectWithTag("VariableHolder");
        if (variableHolderObject != null)
        {
            variableHolder = variableHolderObject.GetComponent<VariableHolder>();
        }
        else
        {
            Debug.LogError("VariableHolder GameObject not found!");
        }

        SetupRangeSlider();
        SetupBackButtons();
    }
    private void SetupRangeSlider()
    {
        rangeSlider.minValue = 60;
        rangeSlider.maxValue = 360;
        rangeSlider.wholeNumbers = true;
        rangeSlider.value = 60;
    }

  private void SetupBackButtons()
    {
        weaponBackButton.onClick.AddListener(ReturnToMainMenu);
        rangeBackButton.onClick.AddListener(ReturnToMainMenu);
    }
    public void ConfirmWeaponSelection()
    {
        if (variableHolder != null)
        {
            variableHolder.left_weapon = leftWeaponDropdown.options[leftWeaponDropdown.value].text;
            variableHolder.right_weapon = rightWeaponDropdown.options[rightWeaponDropdown.value].text;
        }
        
        ReturnToMainMenu();
    }
      public void ConfirmRangeSelection()
    {
        if (variableHolder != null)
        {
            variableHolder.range = (int)rangeSlider.value;
        }
        
        ReturnToMainMenu();
    }

   private void ReturnToMainMenu()
{
    Debug.Log("ReturnToMainMenu called");
    weaponSelectionPanel.SetActive(false);
    rangeSelectionPanel.SetActive(false);
    mainMenuPanel.SetActive(true);
}
}