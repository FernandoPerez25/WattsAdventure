using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float verticalDeadZone = 1.5f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position;

        // Siempre sigue al jugador en X
        targetPosition.x = target.position.x;

        // Solo sigue al jugador en Y cuando sale de la zona muerta
        float distanceY = Mathf.Abs(target.position.y - transform.position.y);

        if (distanceY > verticalDeadZone)
        {
            targetPosition.y = target.position.y;
        }

        // Aplicar límites
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Movimiento suave
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}