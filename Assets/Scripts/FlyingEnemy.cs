using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [Header("Patrulla")]
    [SerializeField] private float patrolDistance = 3f;
    [SerializeField] private float patrolSpeed = 2f;

    [Header("Persecución")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float loseRange = 7f;
    [SerializeField] private float chaseSpeed = 3f;

    private Vector3 startPosition;
    private bool chasing = false;

    private float direction = 1f;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float distance = Vector2.Distance(
            transform.position,
            player.position
        );


        if (!chasing && distance <= detectionRange)
        {
            chasing = true;
        }

        if (chasing && distance >= loseRange)
        {
            chasing = false;
        }


        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }


    void Patrol()
    {
        transform.position +=
            Vector3.right * direction * patrolSpeed * Time.deltaTime;


        float distanceFromStart =
            transform.position.x - startPosition.x;


        if (Mathf.Abs(distanceFromStart) >= patrolDistance)
        {
            direction *= -1;
            Flip(direction);
        }
    }


    void ChasePlayer()
    {
        Vector2 direction =
            (player.position - transform.position).normalized;


        transform.position +=
            (Vector3)direction * chaseSpeed * Time.deltaTime;


        if (direction.x != 0)
        {
            Flip(direction.x);
        }
    }


    void Flip(float direction)
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}