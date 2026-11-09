using UnityEngine;

public class RangedEnemy : BaseEnemy
{

    public GameObject bulletPrefab;
    public float speed = 10f;
    private float angle;

    protected override void Update()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        self.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        base.Update();
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle - 90f));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = (target.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
}
