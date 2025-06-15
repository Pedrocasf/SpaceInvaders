using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireRandomEnemy();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireRandomEnemy()
    {
        List<Transform> livingEnemies = new List<Transform>();

        foreach (Transform enemy in transform)
        {
            if (enemy != null)
                livingEnemies.Add(enemy.Find("firePoint").gameObject.transform);
        }

        if (livingEnemies.Count == 0) return;

        Transform shooter = livingEnemies[Random.Range(0, livingEnemies.Count)];

        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        GameObject bullet = Instantiate(bulletPrefab, shooter.position, rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
            rb.linearVelocity = Vector3.back * bulletSpeed;
        Destroy(bullet, 5f);
    }
}