using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private PlayerMovement movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float speed = Mathf.Abs(rb.velocity.x);

        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", movement.IsGrounded);
    }
}