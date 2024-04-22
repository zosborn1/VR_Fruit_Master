using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableHolder : MonoBehaviour
{
    public int high_score = 0;

    [Range(60, 360)]
    public int range = 60;

    public string left_weapon;
    public string right_weapon;
}
