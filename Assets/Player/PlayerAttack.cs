using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 firePointLocalPosition;

    [SerializeField] private GameObject wrenchPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int maxWrenches = 3;

    private int activeWrenches = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        firePointLocalPosition = firePoint.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");
            ThrowWrench();
        }
        if (spriteRenderer.flipX)
        {
            firePoint.localPosition = new Vector3(
                -Mathf.Abs(firePointLocalPosition.x),
                firePointLocalPosition.y,
                firePointLocalPosition.z
            );
        }
        else
        {
            firePoint.localPosition = new Vector3(
                Mathf.Abs(firePointLocalPosition.x),
                firePointLocalPosition.y,
                firePointLocalPosition.z
            );
        }
    }

    private void ThrowWrench()
    {
        if (activeWrenches >= maxWrenches)
        {
            return;
        }

        GameObject wrench = Instantiate(
            wrenchPrefab,
            firePoint.position,
            Quaternion.identity
        );

        activeWrenches++;

        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D wrenchCollider = wrench.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(playerCollider, wrenchCollider);

        WrenchProjectile projectile = wrench.GetComponent<WrenchProjectile>();

        projectile.SetPlayer(this);

        if (spriteRenderer.flipX)
        {
            projectile.SetDirection(Vector2.left);
        }
        else
        {
            projectile.SetDirection(Vector2.right);
        }
    }

    public void WrenchDestroyed()
    {
        activeWrenches--;
    }
}