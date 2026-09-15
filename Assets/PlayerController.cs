using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;
    [SerializeField]
    private float jumpforce = 10f;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float minGroundNormalY = 0.7f;

    Rigidbody2D rb;
    private float moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = false;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y >= minGroundNormalY)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
