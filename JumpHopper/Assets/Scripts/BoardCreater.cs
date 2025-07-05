using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreater : MonoBehaviour
{
    public GameObject normalboard;
    public GameObject jumpingBoard;
    public GameObject miniBoard;

    private float distance = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 7; i++)
        {
            Instantiate(normalboard, new Vector3(distance * i, distance * i, distance * i), Quaternion.identity);
        }

        Instantiate(jumpingBoard, new Vector3(30f, 23f, 30f), Quaternion.identity);
        Instantiate(jumpingBoard, new Vector3(34f, 29f, 34f), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
