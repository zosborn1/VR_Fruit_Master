using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneration : MonoBehaviour
{
    private int force_vertical = 200;
    private int force_horizontal = 70;

    private int pseudo_random_base = 10000;
    private int pseudo_random_decay = 10;
    private int chance;

    public GameObject[] fruits;

    void CreateFruit(GameObject fruit_type, double spawn_angle) {
        spawn_angle = spawn_angle/180.0*System.Math.PI + System.Math.PI/2.0;
        float spawn_x = (float)System.Math.Cos(spawn_angle)*5.5f;
        float spawn_z = (float)System.Math.Sin(spawn_angle)*5.5f;

        GameObject fruit = Instantiate(fruit_type, new Vector3(spawn_x, 0.75f, spawn_z), Quaternion.identity);

        fruit.transform.Rotate(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));

        float random = (float)(Random.Range(-100, 100))/100.0f;
        double target = spawn_angle - System.Math.PI + random*System.Math.PI/12.0f;

        float target_x = (float)System.Math.Cos(target)*6;
        float target_z = (float)System.Math.Sin(target)*6;
        fruit.GetComponent<Rigidbody>().AddForce(target_x*force_horizontal, force_vertical + Random.Range(0, 40), target_z*force_horizontal);
    }

    void Start() {
        chance = pseudo_random_base;
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, chance) <= VariableHolder.range) {
            GameObject fruit = fruits[Random.Range(0,fruits.Length-1)];
            double spawn_angle = (double)(Random.Range(0, VariableHolder.range)) - (double)VariableHolder.range/2.0;
            CreateFruit(fruit, spawn_angle);

            chance = pseudo_random_base;
        } else {
            chance -= pseudo_random_decay;
        }
    }
}
