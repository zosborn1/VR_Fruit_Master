using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstance : MonoBehaviour
{
    public float decay_time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        decay_time -= Time.deltaTime;
        if(decay_time <= 0) {
            Destroy(this.gameObject);
        }
    }
}
