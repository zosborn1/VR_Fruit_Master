using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class FruitScript : MonoBehaviour
{
    // private GameObject game_controller;
    public Material cross_section;
    public float cut_force = 500;

    void setupSliced(GameObject component, Vector3 velocity) {
        component.tag = "SlicedFruit";
        component.name = "SlicedFruit";
        Rigidbody rigid = component.AddComponent<Rigidbody>();
        MeshCollider collider = component.AddComponent<MeshCollider>();
        collider.convex = true;
        rigid.velocity = velocity;
        rigid.AddExplosionForce(cut_force, component.transform.position, 1);
        component.AddComponent<DecayScript>();
    }

    void sliceFruit(Collider weapon) {
        Transform plane = weapon.gameObject.transform.Find("SlicePlane").transform;

        SlicedHull hull = this.gameObject.Slice(plane.position, plane.up);

        Vector3 velocity = this.gameObject.GetComponent<Rigidbody>().velocity;

        if(hull != null) {
            GameObject upperHull = hull.CreateUpperHull(this.gameObject, cross_section);
            setupSliced(upperHull, velocity);
            

            GameObject lowerHull = hull.CreateLowerHull(this.gameObject, cross_section);
            setupSliced(lowerHull, velocity);
        }
        
        Destroy(this.gameObject);
    }

    void smashFruit() {
        Destroy(this.gameObject);
    }

    // OnCollisionEnter
    void OnTriggerEnter(Collider collision) {
        switch(collision.gameObject.tag) {
            case "Sword":
                // game_controller.GetComponent<GameController>().score += 10;
                sliceFruit(collision);
                break;
            case "Axe":
                // game_controller.GetComponent<GameController>().score += 10;
                sliceFruit(collision);
                break;
            case "Bat":
                // game_controller.GetComponent<GameController>().score += 10;
                smashFruit();
                break;
            case "Player":
                // game_controller.GetComponent<GameController>().score -= 4;
                smashFruit();
                break;
            default:
                // game_controller.GetComponent<GameController>().score -= 2;
                // smashFruit();
                break;
        }
    }

    void Start() {
        // game_controller = GameObject.FindGameObjectWithTag("GameController");
    }
}
