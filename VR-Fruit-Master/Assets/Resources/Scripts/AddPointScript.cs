using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddPointScript : MonoBehaviour
{
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = this.gameObject.GetComponent<TextMeshProUGUI>();
        if(points >= 0) {
            text.text = "+" + points;
            text.color = new Color(200, 200, 100, 255);
            
        } else {
            text.text = "" + points;
            text.color = new Color(255, 50, 50, 255);
        }
        this.gameObject.transform.localPosition = new Vector3(0, -100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.localPosition.y >= -50) {
            Destroy(this.gameObject);
        } else {
            this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0, Time.deltaTime*50, 0);
        }
        
    }
}
