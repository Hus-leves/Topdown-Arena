using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    void FixedUpdate()
    {
        Vector2 direction = Vector2.ClampMagnitude(moveInput, 1f);
        rb.linearVelocity = direction * moveSpeed;
    }
}
