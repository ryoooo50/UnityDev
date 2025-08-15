using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab; // 弾丸のプレハブ
    public Transform firePoint;
    public float fireRate = 0.5f; // 発射間隔
    public float bulletSpeed = 20f; // 弾丸の速度
    // Start is called before the first frame update
    void Start()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is not assigned in the Gun script.");
        }
        // bulletPrefab = Instantiate(bulletPrefab, player.transform.position + firePoint.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet does not have a Rigidbody component.");
        }

        Destroy(bullet, 3f); // 2秒後に弾丸を削除
    }
}
