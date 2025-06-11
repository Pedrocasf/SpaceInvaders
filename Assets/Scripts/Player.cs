using UnityEngine;

public class Player : DamageableEntity
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int health;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float screenBorderOffset;

    private Rigidbody rb;
    private Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            weapon.Shoot();
        }
        Vector3 newPosition = rb.position + (moveDirection * moveSpeed * Time.deltaTime);

        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        Vector3 center = (Vector3)mainCamera.transform.position;
        float minX = center.x - width + screenBorderOffset;
        float maxX = center.x + width - screenBorderOffset;
        float minY = center.y - height + screenBorderOffset;
        float maxY = center.y + height - screenBorderOffset;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        rb.MovePosition(newPosition);

    }

    public override void Die()
    {
        base.Die();
    }
}
