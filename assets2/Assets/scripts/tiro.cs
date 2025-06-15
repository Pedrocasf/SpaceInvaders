using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed = 10f;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inimigo"))
        {
            other.GetComponent<enemyHealth>()?.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
