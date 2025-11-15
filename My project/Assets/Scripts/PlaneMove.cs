using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Transform player;
    private bool isNowStage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < 1.0f) {
            isNowStage = true;
        }


        //OnTriggerExitとか使ったほうがいい
        if (distance > 5f && isNowStage) {
            Destroy(gameObject);
        }
        
    }
}
