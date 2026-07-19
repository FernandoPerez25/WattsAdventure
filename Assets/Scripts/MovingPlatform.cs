using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float speed = 2f;

    [SerializeField] private Vector2 moveDirection = Vector2.up;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        // Asegura que la dirección tenga longitud 1
        moveDirection.Normalize();
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * moveDistance;

        transform.position = startPosition +
            (Vector3)(moveDirection * movement);
    }
}