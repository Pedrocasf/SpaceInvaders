using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationController : MonoBehaviour
{
    [Header("Formação")]
    public GameObject enemyPrefab;
    public int rows = 5;
    public int columns = 11;
    public int rowsMax = 5;
    public int columnsMax = 11;
    public float spacingX = 1.5f;
    public float spacingY = 1.5f;
    public int rounds;
    private Vector3 initialPosition;
    public List <GameObject> enemyInScene;

    [Header("Movimento")]
    public float moveSpeed = 2f;
    public float moveDownAmount = 1f;
    public float boundaryX = 9f;

    private Vector3 direction = Vector3.right;

    void Start()
    {
        initialPosition = transform.position;
        SpawnEnemies();
    }

    void Update()
    {
        MoveFormation();
        if (enemyInScene.Count <= 0)
        {
            transform.position = initialPosition;
            if (rows < rowsMax)
                rows++;
            moveSpeed += 0.5f;
            SpawnEnemies();
            rounds++;
        }
        for (int i = 0; i < enemyInScene.Count; i++)
        {
            if (enemyInScene[i] == null)
            {
                enemyInScene.Remove(enemyInScene[i]);
            }
        }
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = transform.position + new Vector3(col * spacingX, 0, -row * spacingY);
                Quaternion rotation = Quaternion.Euler(90, 0, 0);
                var enemy = Instantiate(enemyPrefab, position, rotation, transform);
                enemyInScene.Add(enemy);
            }
        }
    }

    void MoveFormation()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;

        foreach (Transform enemy in transform)
        {
            if (enemy == null) continue;

            if (enemy.position.x > boundaryX && direction == Vector3.right)
            {
                direction = Vector3.left;
                transform.position += Vector3.back * moveDownAmount;
                break;
            }

            if (enemy.position.x < -boundaryX && direction == Vector3.left)
            {
                direction = Vector3.right;
                transform.position += Vector3.back * moveDownAmount;
                break;
            }
        }
    }
}