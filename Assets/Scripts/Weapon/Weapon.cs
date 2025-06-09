using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileOrign;
    [SerializeField] private Alliance alliance;
    [SerializeField] private float projectileSpeed;
    public void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab,projectileOrign.position,Quaternion.identity);
        projectile.Initialize(transform.up * projectileSpeed, alliance);
    }
}