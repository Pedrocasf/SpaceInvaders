using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private Alliance alliance;
    private Rigidbody rb;

    public void Initialize(Vector3 direction, Alliance isAllied)
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction;
        this.alliance = isAllied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageble) && !damageble.IsAllied(alliance))
        {
            damageble.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
