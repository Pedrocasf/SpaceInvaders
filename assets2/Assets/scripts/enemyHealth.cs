using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public int point;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreManager.instance.AddScore(point);
        Destroy(gameObject);
    }
}