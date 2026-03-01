using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trashPrefab;

    public int dropRate = 3;
    public float spawnRange = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) < dropRate)
        {
            float x = Random.Range(-spawnRange, spawnRange);
            float z = Random.Range(-spawnRange, spawnRange);

            Vector3 dropPos = new Vector3(x, 15, z);

            Instantiate(trashPrefab, dropPos, Quaternion.identity);
        }
        
    }
}
