using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {  
        
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(x * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, z * speed * Time.deltaTime);
        
    }
}
