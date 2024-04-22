using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public Dropdown leftWeaponDropdown;
    public Dropdown rightWeaponDropdown;
    public Slider rangeSlider;
    public GameObject mainMenuPanel;
    public GameObject weaponSelectionPanel;
    public GameObject rangeSelectionPanel;

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
    }

    private void SetupRangeSlider()
    {
        rangeSlider.minValue = 60;
        rangeSlider.maxValue = 360;
        rangeSlider.wholeNumbers = true;
        rangeSlider.value = 60;
    }

    public void ConfirmWeaponSelection()
    {
        if (variableHolder != null)
        {
            variableHolder.left_weapon = leftWeaponDropdown.options[leftWeaponDropdown.value].text;
            variableHolder.right_weapon = rightWeaponDropdown.options[rightWeaponDropdown.value].text;
        }
        
        weaponSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ConfirmRangeSelection()
    {
        if (variableHolder != null)
        {
            variableHolder.range = rangeSlider.value;
        }
        
        rangeSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}