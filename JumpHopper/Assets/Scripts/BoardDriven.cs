using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDriven : MonoBehaviour
{

    public float speed = 2f;
    public float distance = 3f;
    private float startX;

    private Vector3 lastPos;
    public Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("MoveNow", 5f);
        startX = transform.position.x;
        lastPos = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = startX + Mathf.PingPong(Time.fixedTime * speed, distance);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        delta = transform.position - lastPos;
        lastPos = transform.position;
    }

    void MoveNow() 
    {
        
        Debug.Log("5秒後に動き出す");
    }
}
