using System.Collections;
using UnityEngine;

public class WrenchProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private float lifeTime = 3f;

    private Vector2 direction;
    private PlayerAttack playerAttack;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);

        playerAttack.WrenchDestroyed();

        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    public void SetPlayer(PlayerAttack player)
    {
        playerAttack = player;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);

            playerAttack.WrenchDestroyed();

            Destroy(gameObject);
        }
    }
}