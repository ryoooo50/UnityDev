using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 3.0f, -10f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) {
            return;
        }

        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}
