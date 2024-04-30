using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;


public class FruitScript : MonoBehaviour
{

    public int type;
    public Material cross_section;
    public float force = 500;
    public GameObject smashed_version;
    
    private GameObject game_controller;



    void changePoints(int point, bool hit) {
        game_controller.GetComponent<GameController>().updateScore(point, hit, type);
    }   

    void setupSliced(GameObject component, Vector3 velocity) {
        component.tag = "SlicedFruit";
        component.name = "SlicedFruit";
        Rigidbody rigid = component.AddComponent<Rigidbody>();
        MeshCollider collider = component.AddComponent<MeshCollider>();
        collider.convex = true;
        rigid.velocity = velocity;
        rigid.AddExplosionForce(force, component.transform.position, 1);
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

    void setupSmashed(GameObject component, Vector3 velocity, Vector3 explosion_position) {
        component.tag = "SmashedFruit";
        Rigidbody rigid = component.GetComponent<Rigidbody>();
        rigid.velocity = velocity;
        // rigid.AddExplosionForce(force, explosion_position, 10);
        component.GetComponent<Rigidbody>().velocity = velocity;
    }

    void smashFruit() {
        GameObject creation = Instantiate(smashed_version, new Vector3(0, 0, 0), Quaternion.identity);
        creation.transform.position = this.gameObject.transform.position;
        creation.transform.rotation = this.gameObject.transform.rotation;

        Vector3 velocity = this.gameObject.GetComponent<Rigidbody>().velocity;

        foreach(Transform child in creation.transform) {
            setupSmashed(child.gameObject, velocity, creation.transform.position);
        }
        creation.transform.DetachChildren();
        Destroy(creation);
        Destroy(this.gameObject);
    }

    void Start() {
        game_controller = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnTriggerEnter(Collider collision) {
        switch(collision.gameObject.tag) {
            case "Sword":
                changePoints(100, true);
                sliceFruit(collision);
                break;
            case "Axe":
                changePoints(100, true);
                sliceFruit(collision);
                break;
        }
    }

    void OnCollisionEnter(Collision collision) {
        switch(collision.gameObject.tag) {
            case "Player":
                changePoints(-50, false);
                game_controller.GetComponent<GameController>().loseHeart();
                smashFruit();
                break;
            case "Hand":
                changePoints(100, true);
                smashFruit();
                break;
            case "Bat":
                changePoints(100, true);
                smashFruit();
                break;
            case "Fruit":
            case "SlicedFruit":
            case "SmashedFruit":
                break;
            default:
                changePoints(-25, false);
                smashFruit();
                break;
        }
    }
}
