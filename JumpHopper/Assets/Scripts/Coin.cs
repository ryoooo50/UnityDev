using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public GameObject coinEffectPrefab;
    public AudioClip coinPickupSound;
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
                Destroy(effectInstance, 2.0f);
            }

            if (coinPickupSound != null)
            {
                GameObject audioObject = new GameObject("CoinPickupAudio");
                audioObject.transform.position = transform.position;
        
                AudioSource audioSource = audioObject.AddComponent<AudioSource>();

                audioSource.clip = coinPickupSound;

                audioSource.Play();

                Destroy(audioObject, coinPickupSound.length);
                Debug.Log("Coin pickup sound played.");
            }

            Destroy(gameObject);

        }
    }
}
