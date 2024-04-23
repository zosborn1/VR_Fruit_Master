using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayScript : MonoBehaviour
{
    public float decay_time = 3.0f;
    private float time;
    private bool start_timer = false;
    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        materials = this.gameObject.GetComponent<Renderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        if(start_timer) {
            time += Time.deltaTime;

            if(time >= decay_time) {
                Destroy(this.gameObject);
            }
            float percent = time/decay_time;

            foreach(Material material in materials){
                Color temp = material.color;
                temp.a = (1.0f - percent);
                material.color = temp;
            }
        } else if(this.gameObject.transform.position.y <= -20) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Untagged") 
            start_timer = true;
    }
}
