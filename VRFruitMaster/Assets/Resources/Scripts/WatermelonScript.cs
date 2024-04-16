using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Fruit") {
            return;
        }
        else if(collision.gameObject.name != "Weapon") {
            Destroy(this.gameObject);
        }
    }

    // void Start() {
    //     this.gameObject.GetComponent<Rigidbody>().AddForce(0, 500, 0);
    // }
}
