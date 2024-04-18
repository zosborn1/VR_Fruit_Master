using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSelector : MonoBehaviour
{
    [Range(60, 360)]
    public int range;

    public GameObject test;

    void Start() {
        //test = GameObject.FindGameObjectWithTag("Information");
    }
}
