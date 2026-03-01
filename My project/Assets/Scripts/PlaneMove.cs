using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public Transform player;
    private static PlaneMove activeStage = null;
    private Rigidbody rb;

    public 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activeStage == this) {
            if (Input.GetKey(KeyCode.W)) {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }
        
    }
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            activeStage = this;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (activeStage == this) {
                activeStage = null;
            }

            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        // もし自分がアクティブなまま消える場合、アクティブ登録を解除する
        if (activeStage == this)
        {
            activeStage = null;
        }
    }


}
