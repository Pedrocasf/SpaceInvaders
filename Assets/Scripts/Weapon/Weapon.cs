using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileOrign;
    [SerializeField] private Alliance alliance;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float coolDownTime;
    private float coolDownUntilNextPress;
    public void Shoot()
    {
        if (coolDownUntilNextPress < Time.time)
        {
            Projectile projectile = Instantiate(projectilePrefab, projectileOrign.position, Quaternion.identity);
            projectile.Initialize(transform.up * projectileSpeed, alliance);
            coolDownUntilNextPress = Time.time + coolDownTime;
        }
    }
}