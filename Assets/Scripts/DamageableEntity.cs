using UnityEngine;
public class DamageableEntity: MonoBehaviour, IDamageable
{
    [SerializeField] protected RangedFloat life;
    [SerializeField] private Alliance alliance;

    public bool IsDead { get; private set; }

    public bool IsAllied(Alliance alliance)
    {
        return this.alliance == alliance; 
    }

    public virtual void TakeDamage(int damage)
    {
        life.CurrentValue -= damage;
        if (life.IsMinValue())
        {
            Die();
        }
    }

    public virtual void Die()
    {
        IsDead = true;
        Destroy(gameObject);
    }
}
