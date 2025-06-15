using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float baseFireRate = 1f; 
    public float T;

    private EnemyFormationController formation;

    void Start()
    {
        formation = Object.FindFirstObjectByType<EnemyFormationController>();
    }

    void Update()
    {
        if (formation == null) return;

        float fireRate = Mathf.Max(0.2f, baseFireRate - (formation.rounds * 0.1f));

        if (Input.GetKey(KeyCode.Space) && T < Time.time)
        {
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            T = Time.time + fireRate;
        }
    }
}