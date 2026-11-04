using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float damage = 50f;
    public List<GameObject> Hits = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Sword" || Hits.Contains(other.gameObject)) return;

        var target = other.GetComponentInParent<IDamagable>();
        if (target == null) return;
        Hits.Add(other.gameObject);
        target.TakeDamage(damage);
    }
}
