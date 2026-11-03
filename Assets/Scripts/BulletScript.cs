using System.Collections;
using UnityEngine;

public class BulletScript : BaseProjectile
{

    public float damage = 30f;
    private void Start()
    {
        StartCoroutine(Timeout());
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var target = other.GetComponent<IDamagable>();
            target.TakeDamage(damage);
        }
    }
}
