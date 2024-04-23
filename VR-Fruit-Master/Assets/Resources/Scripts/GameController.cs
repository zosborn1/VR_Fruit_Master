using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject fruit_generation;

    public GameObject timer;
    public GameObject countdown;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject points;

    private GameObject variable_holder;
    public GameObject left_hand;
    public GameObject right_hand;

    private TextMeshProUGUI timer_text;
    private TextMeshProUGUI countdown_text;

    public int score = 0;
    public float time_left = 90.0f;
    public float start_time = 5.0f;

    public bool game_start = false;

    void clearWeapons() {
        if(!left_hand.transform.Find("Weapon"))
            Destroy(left_hand.transform.Find("Weapon"));
        if(!right_hand.transform.Find("Weapon"))
            Destroy(right_hand.transform.Find("Weapon"));
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

    void updateCountdown() {
        int sec = Mathf.FloorToInt(start_time);
        countdown_text.text = string.Format("{00}", sec);
    }

    void updateTime() {
        int min = Mathf.FloorToInt(time_left/60);
        int sec = Mathf.FloorToInt(time_left%60);

        if(min >= 1) {
            if(sec >= 10) {
                timer_text.text = string.Format("1:{00}", sec);
            } else {
                timer_text.text = string.Format("1:0{0}", sec);
            }
        } else {
            if(sec <= 30) {
                timer_text.color = new Color(240, 50, 0, 255);
                switch(sec) {
                    case 3:
                        timer_text.fontSize = 60;
                        break;
                    case 2:
                        timer_text.fontSize = 70;
                        break;
                    case 1:
                        timer_text.fontSize = 80;
                        break;
                    case 0:
                        timer_text.fontSize = 90;
                        timer_text.color = new Color(255, 0, 0, 255);
                        break;
                }
            }
            timer_text.text = string.Format("{00}", sec);
        }
    }

    void Start() {
        countdown_text = countdown.GetComponent<TextMeshProUGUI>();
        timer_text = timer.GetComponent<TextMeshProUGUI>();
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

    void Update() {
        if(!game_start) {
            start_time -= Time.deltaTime;
            updateCountdown();

            if(start_time <= 0) {
                fruit_generation.SetActive(true);

                timer.SetActive(true);
                points.SetActive(true);
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                countdown.SetActive(false);
                game_start = true;
            }
        } else {
            time_left -= Time.deltaTime;
            
            if(time_left >= 0) {
                updateTime();
            } else {
                fruit_generation.SetActive(false);
            }
        }
    }
}
