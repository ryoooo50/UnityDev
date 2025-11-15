using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(0.001f,0.001f,0.001f);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-0.001f,-0.001f,-0.001f);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(0, 0.005f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(0, -0.005f, 0);
        }
    }
}
