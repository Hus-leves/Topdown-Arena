using UnityEngine;
using UnityEngine.UI;


public abstract class BaseEnemy : MonoBehaviour, IDamagable
{
    public enum attackType
    {
        melee,
        ranged
    }
    public float maxHp;
    public float attackCooldown;
    public float attackRange;
    public float moveSpeed = 0.5f;
    public bool canAttack;
    public GameObject hpBar;
    public GameObject target;
    public attackType dropdown = new attackType();


    private float hp;
    private float cd;
    public abstract void Attack();

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        hp = maxHp;
    }

    protected virtual void Update()
    {
        float side = target.transform.position.x > transform.position.x ? 1f : -1f;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * side;
        transform.localScale = scale;
        
        Vector3 hpscale = hpBar.transform.localScale;
        hpBar.transform.localScale = hpscale;
        

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
        hpBar.transform.localScale = new Vector3(0.245f * (hp / maxHp), 0.3075f, 1f);
        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
