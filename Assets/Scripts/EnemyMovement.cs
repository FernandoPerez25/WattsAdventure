using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool canTurn = true;

    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 moveDirection = movingRight ? Vector2.right : Vector2.left;

        // Mover enemigo
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Detectar suelo
        RaycastHit2D groundHit = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            0.3f,
            groundLayer
        );

        // Detectar pared
        RaycastHit2D wallHit = Physics2D.Raycast(
            wallCheck.position,
            moveDirection,
            0.2f,
            groundLayer
        );

        if ((!groundHit || wallHit) && canTurn)
        {
            TurnAround();
        }
    }

    private void TurnAround()
    {
        canTurn = false;

        movingRight = !movingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        Invoke(nameof(EnableTurn), 0.2f);
    }

    private void EnableTurn()
    {
        canTurn = true;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;

        Gizmos.DrawLine(
            groundCheck.position,
            groundCheck.position + Vector3.down * 0.5f
        );

        if (wallCheck != null)
        {
            Gizmos.color = Color.red;

            Vector3 direction = movingRight ? Vector3.right : Vector3.left;

            Gizmos.DrawLine(
                wallCheck.position,
                wallCheck.position + direction * 0.4f
            );
        }
    }
}