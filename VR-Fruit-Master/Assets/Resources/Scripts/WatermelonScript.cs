using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Weapon") {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Fruit") {
            return;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    // void Start() {
    //     this.gameObject.GetComponent<Rigidbody>().AddForce(0, 500, 0);
    // }
}
