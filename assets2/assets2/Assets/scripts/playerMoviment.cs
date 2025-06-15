using UnityEngine;
public class playerMoviment : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(moveX * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        rb.linearVelocity = velocity;
    }

    
}