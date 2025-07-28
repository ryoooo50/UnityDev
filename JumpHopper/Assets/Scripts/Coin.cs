using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public GameObject coinEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                // Add coin to the GameManager's coin count
                GameManager.instance.AddCoin();
            }

            if (coinEffectPrefab != null)
            {
                // Instantiate the coin effect at the coin's position
                GameObject effectInstance = Instantiate(coinEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject, 2.0f);
            }

            Destroy(gameObject);
            
        }
    }
}
