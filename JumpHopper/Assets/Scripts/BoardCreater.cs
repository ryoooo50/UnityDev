using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreater : MonoBehaviour
{
    public GameObject boardprefabs;

    private float distance = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            Instantiate(boardprefabs, new Vector3(distance * i, distance * i, distance * i), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
