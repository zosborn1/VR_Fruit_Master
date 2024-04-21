using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(60, 360)]
    public int range;

    private string left_weapon;
    private string right_weapon;

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    private GameObject variable_holder;
    public GameObject left_hand;
    public GameObject right_hand;

    void clearWeapons(GameObject player) {

    }

    void giveWeapon(GameObject prefab, bool is_left) {
        GameObject weapon = Instantiate(prefab);

        if(is_left) {
            weapon.transform.parent = left_hand.transform;
        } else {
            weapon.transform.parent = right_hand.transform;
        }

        weapon.transform.localPosition = new Vector3(0,0,0);
        weapon.name = "Weapon";
    }

    void Start() {
        variable_holder = GameObject.FindGameObjectWithTag("VariableHolder");

        range = variable_holder.GetComponent<VariableHolder>().range;

        switch(variable_holder.GetComponent<VariableHolder>().left_weapon) {
            case "weapon1":
                giveWeapon(weapon1, true);
                break;
            case "weapon2":
                giveWeapon(weapon2, true);
                break;
            case "weapon3":
                giveWeapon(weapon3, true);
                break;
            case "weapon4":
                giveWeapon(weapon4, true);
                break;
            default:
                break;
        }
        switch(variable_holder.GetComponent<VariableHolder>().right_weapon) {
            case "weapon1":
                giveWeapon(weapon1, false);
                break;
            case "weapon2":
                giveWeapon(weapon2, false);
                break;
            case "weapon3":
                giveWeapon(weapon3, false);
                break;
            case "weapon4":
                giveWeapon(weapon4, false);
                break;
            default:
                break;
        }
    }
}
