using UnityEngine;


public abstract class BaseEnemy : MonoBehaviour, IDamagable
{
    public enum attackType
    {
        melee,
        ranged
    }
    public float hp;
    public float attackCooldown;
    public float attackRange;
    public float moveSpeed = 0.5f;
    public bool canAttack;
    public GameObject target;
    public attackType dropdown = new attackType();


    private float cd;
    public abstract void Attack();

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        float side = target.transform.position.x > transform.position.x ? 1f : -1f;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * side;
        transform.localScale = scale;

        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {
            if(cd >= attackCooldown)
            {
                canAttack = true;
                cd = 0f;
                Attack();
            }
        }
        else
        {
            canAttack = false;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        cd += Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
