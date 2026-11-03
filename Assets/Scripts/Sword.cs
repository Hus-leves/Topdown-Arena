using UnityEngine;

public abstract class Sword : MonoBehaviour
{
    public float damage = 10f;
    public float downPos = -50f;
    public float upPos = 50f;
    public float swingTime = 0.2f;
    public float coolDown = 0.5f;
    public bool swing;

    private float cd;
    private float rotation;
    private float t = 1f;
    private bool canHit;

    IDamagable owner;

    protected virtual void Awake()
    {
        owner = GetComponentInParent<IDamagable>();
    }

    protected virtual void Update()
    {
        if (cd <= 0f && swing)
        {
            transform.localRotation = Quaternion.Euler(0, 0, upPos);
            canHit = true;
            cd = coolDown;
            t = 0f;
            swing = false;
        }
        cd -= Time.deltaTime;

        if (t <= 1f)
        {
            t += Time.deltaTime / swingTime;
            t = Mathf.Clamp01(t);
            rotation = Mathf.Lerp(upPos, downPos, t);
        }
        transform.localRotation = Quaternion.Euler(0f, 0f, rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (cd >= 0f && canHit)
        {
            var target = other.GetComponentInParent<IDamagable>();
            if (target == null || target == owner) return;
            target.TakeDamage(damage);
            canHit = false;
        }
    }
}
