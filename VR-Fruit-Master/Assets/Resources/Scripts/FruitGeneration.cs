using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneration : MonoBehaviour
{
    [Range(1, 100)]
    public int frequency;

    private int range;
    private GameObject range_selector;

    private int force_vertical = 280;
    private int force_horizontal = 90;

    public GameObject watermelon;
    private GameObject[] all_fruits;

    void CreateFruit(GameObject fruit_type, double spawn_angle) {
        spawn_angle = spawn_angle/180.0*System.Math.PI + System.Math.PI/2.0;
        float spawn_x = (float)System.Math.Cos(spawn_angle)*4.5f;
        float spawn_z = (float)System.Math.Sin(spawn_angle)*4.5f;

        GameObject fruit = Instantiate(fruit_type, new Vector3(spawn_x, 0.5f, spawn_z), Quaternion.identity);

        fruit.transform.Rotate(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));

        float random = (float)(Random.Range(-100, 100))/100.0f;
        double target = spawn_angle - System.Math.PI + random*System.Math.PI/6.0f;

    
        float target_x = (float)System.Math.Cos(target)*4;
        float target_z = (float)System.Math.Sin(target)*4;
        fruit.GetComponent<Rigidbody>().AddForce(target_x*force_horizontal, force_vertical, target_z*force_horizontal);
    }

    // Start is called before the first frame update
    void Start()
    {
        range_selector = GameObject.FindGameObjectWithTag("Range Selector Tag");
        range = range_selector.GetComponent<RangeSelector>().range;

        all_fruits = new GameObject[]{watermelon};
    }

    // Update is called once per frame
    void Update()
    {
        range = range_selector.GetComponent<RangeSelector>().range;

        if(Random.Range(1, 1000) <= frequency) {
            GameObject fruit = all_fruits[Random.Range(0,all_fruits.Length-1)];
            double spawn_angle = (double)(Random.Range(0, range)) - (double)range/2.0;
            int target_angle = Random.Range(0, 30);

            CreateFruit(fruit, spawn_angle);
        }
    }
}
