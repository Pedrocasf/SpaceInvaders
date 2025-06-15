using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth playerHealth = other.GetComponent<playerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject); 
        }
        else if (!other.CompareTag("inimigo")) 
        {
            Destroy(gameObject);
        }
    }
}
