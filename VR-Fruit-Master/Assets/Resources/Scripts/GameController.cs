using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GAME_STATE {COUNTDOWN, GAME_PLAY, GAME_DONE, DISPLAY_END, RETURN_MENU};

    [Header("Prefabs")]
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject[] fruit;
    public GameObject add_point;

    [Header("UI/Player")]
    public GameObject whole_ui;
    public GameObject timer;
    public GameObject countdown;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject points;
    public GameObject left_hand;
    public GameObject right_hand;
    public GameObject end_display;
    public GameObject end_score;

    [Header("Scene Objects")]
    public GameObject fruit_generation;
    public GameObject wall_generation;

    [Header("Other")]
    public int score = 0;
    public GAME_STATE game_state;
    public List<int> fruit_hit;
    public List<int> fruit_miss;

    private float global_time;
    private float countdown_time = 5.5f;
    private float game_play_time = 90.0f;
    private float display_end_delay = 0.1f;
    private float return_menu_time = 5.0f;

    private TextMeshProUGUI timer_text;
    private TextMeshProUGUI countdown_text;
    private TextMeshProUGUI points_text;

    void clearWeapons() {
        if(left_hand.transform.Find("Weapon") != null)
            Destroy(left_hand.transform.Find("Weapon").gameObject);
        if(right_hand.transform.Find("Weapon") != null)
            Destroy(right_hand.transform.Find("Weapon").gameObject);
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
        int sec = Mathf.FloorToInt(global_time);
        countdown_text.text = string.Format("{00}", sec);
    }

    void updateTime() {
        int min = Mathf.FloorToInt(global_time/60);
        int sec = Mathf.FloorToInt(global_time%60);

        if(min >= 1) {
            timer_text.text = min + ":" + (""+sec).PadLeft(2, '0');
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

    public void updateScore(int value, bool hit, int type) {
        score += value;
        score = Mathf.Max(0, score);
        if(hit) {
            fruit_hit.Add(type);
        } else {
            fruit_miss.Add(type);
        }

        GameObject added_point = Instantiate(add_point, Vector3.zero, Quaternion.identity, whole_ui.transform);
        added_point.GetComponent<AddPointScript>().points = value;

        points_text.text = ("" + score).PadLeft(4, '0');
    }

    void Start() {
        Time.timeScale = 0.8f;
        global_time = countdown_time;

        countdown_text = countdown.GetComponent<TextMeshProUGUI>();
        timer_text = timer.GetComponent<TextMeshProUGUI>();
        points_text = points.GetComponent<TextMeshProUGUI>();
        game_state = GAME_STATE.COUNTDOWN;
        fruit_hit = new List<int>();
        fruit_miss = new List<int>();

        switch(VariableHolder.left_weapon) {
            case 1:
                giveWeapon(weapon1, true);
                break;
            case 2:
                giveWeapon(weapon2, true);
                break;
            case 3:
                giveWeapon(weapon3, true);
                break;
            default:
                break;
        }

        switch(VariableHolder.right_weapon) {
            case 1:
                giveWeapon(weapon1, false);
                break;
            case 2:
                giveWeapon(weapon2, false);
                break;
            case 3:
                giveWeapon(weapon3, false);
                break;
            default:
                break;
        }
    }

    void countDown() {
        updateCountdown();

        if(global_time <= 0) {
            fruit_generation.SetActive(true);
            timer.SetActive(true);
            points.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            countdown.SetActive(false);

            game_state = GAME_STATE.GAME_PLAY;
            global_time = game_play_time;
        }
    } 

    void gamePlay() {
        if(global_time >= 0) {
            updateTime();
        } else {
            fruit_generation.SetActive(false);
            game_state = GAME_STATE.GAME_DONE;
        }
    }

    void gameDone() {
        clearWeapons();
        timer.SetActive(false);
        points.SetActive(false);
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        wall_generation.SetActive(false);

        end_display.SetActive(true);
        end_score.GetComponent<TextMeshProUGUI>().text = "" + score;

        game_state = GAME_STATE.DISPLAY_END;
        
    }

    void displayEnd() {
        if(global_time <= 0) {
            global_time = display_end_delay;

            if(fruit_miss.Count >= 1) {
                GameObject type = fruit[fruit_miss[0]];
                Instantiate(type, new Vector3(-2.828427f, 14, 2.828427f), Quaternion.identity);
                fruit_miss.RemoveAt(0);
            }
            if(fruit_hit.Count >= 1) {
                GameObject type = fruit[fruit_hit[0]];
                Instantiate(type, new Vector3(2.828427f, 14, 2.828427f), Quaternion.identity);
                fruit_hit.RemoveAt(0);
            }

            if(fruit_miss.Count == 0 && fruit_hit.Count == 0) {
                game_state = GAME_STATE.RETURN_MENU;
                global_time = return_menu_time;
            }
        }
    }

    void returnMenu() {
        if(global_time <= 0) {
            SceneManager.LoadScene("StartScene");
        }
    }

    void Update() {
        global_time -= Time.deltaTime*1.25f;

        switch(game_state) {
            case GAME_STATE.COUNTDOWN:
                countDown();
                break;
            case GAME_STATE.GAME_PLAY:
                gamePlay();
                break;
            case GAME_STATE.GAME_DONE:
                gameDone();
                break;
            case GAME_STATE.DISPLAY_END:
                displayEnd();
                break;
            case GAME_STATE.RETURN_MENU:
                returnMenu();
                break;
            default:
                break;
        }
    }
}
