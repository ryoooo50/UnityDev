using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    private float force = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(-transform.right * force * 0.2f);
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(transform.right * force * 1.0f);
        }

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(transform.up * force);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(-transform.right * force);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(-transform.forward * force);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(transform.forward * force);
        }
    }
}
