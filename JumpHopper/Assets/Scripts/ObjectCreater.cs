using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    public GameObject coinPrefab;
    // public Vector3 coinPositionOffset = new Vector3(11.5f, 10f, 0);

    [Header("コイン生成範囲の設定")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = 0.5f;
    public float maxY = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    [Header("生成設定")]
    public int numberOfCoins = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (coinPrefab != null)
        {

            // Create multiple coins at random positions within the specified range
            for (int i = 0; i < numberOfCoins; i++)
            {
                CreateRandomCoin();
            }

            Debug.Log($"{numberOfCoins} coins created in the scene.");
        }
        else
        {
            Debug.LogError("Coin prefab to create is not assigned.");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRandomCoin()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}
