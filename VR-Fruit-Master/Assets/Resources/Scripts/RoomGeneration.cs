using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGeneration : MonoBehaviour
{
    public string skybox;
    private string cur_skybox;

    public GameObject short_left_edge_prefab;
    public GameObject tall_left_edge_prefab;

    public GameObject tall_left_connect_prefab;

    public GameObject short_wall_prefab;
    public GameObject tall_wall_prefab;
    
    public GameObject tall_right_connect_prefab;

    public GameObject tall_right_edge_prefab;
    public GameObject short_right_edge_prefab;

    private GameObject game_controller;
    private int currentRange;
    private int segments;

    GameObject createWall(GameObject prefab, int distance) {
        GameObject creation = Instantiate(prefab, new Vector3(0, 0, distance), Quaternion.identity);
        creation.transform.parent = this.gameObject.transform;
        return creation;
    }

    void clearWalls() {
        foreach(Transform child in this.gameObject.transform){
            Destroy(child.gameObject);
        }
    }

    void updateWalls() {
        GameObject pivot = this.gameObject;

        clearWalls();

        if(currentRange <= 345) {
            // creating left edge of walls
            createWall(short_left_edge_prefab, 3);
            createWall(tall_left_edge_prefab, 5);
            pivot.transform.Rotate(0, -15, 0);
            
            createWall(short_wall_prefab, 3);
            createWall(tall_left_connect_prefab, 5);
            pivot.transform.Rotate(0, -15, 0);

            // creating middle walls
            for(int i = 0; i < segments-3; i++) {
                createWall(short_wall_prefab, 3);
                createWall(tall_wall_prefab, 5);
                pivot.transform.Rotate(0, -15, 0);
            }

            // creating right edge of walls
            createWall(short_wall_prefab, 3);
            createWall(tall_right_connect_prefab, 5);
            pivot.transform.Rotate(0, -15, 0);

            createWall(short_right_edge_prefab, 3);
            createWall(tall_right_edge_prefab, 5);
        } else {
            for(int i = 0; i < segments+1; i++) {
                createWall(short_wall_prefab, 3);
                createWall(tall_wall_prefab, 5);
                pivot.transform.Rotate(0, -15, 0);
            }
        }

        // correcting angle of walls
        pivot.transform.Rotate(0, (float)((double)((segments+1)*15)/2.0 - 7.5), 0);

        // randomize wood texture
        foreach(Transform child in this.gameObject.transform) {
            foreach(Transform child_child in child) {
                if(child_child.name == "Panel") {
                    child_child.gameObject.GetComponent<Renderer>().material = Resources.Load("Wood" + Random.Range(1, 10), typeof(Material)) as Material;
                }
            }
        }

        this.gameObject.transform.localScale = new Vector3(1.25f, 1.0f, 1.25f);
    }

    void updateSkybox() {
        RenderSettings.skybox = Resources.Load(skybox, typeof(Material)) as Material;
    }

    // Start is called before the first frame update
    void Start() 
    {
        game_controller = GameObject.FindGameObjectWithTag("GameController");
        currentRange = VariableHolder.range;
        segments = currentRange/15;

        updateWalls();
        updateSkybox();
    }
}
