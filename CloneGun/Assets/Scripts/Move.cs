using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject target;
    public float speed = 30f;
    public float jumpHeight = 2f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = target.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position - transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        
    }
}
