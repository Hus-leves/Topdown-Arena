using System.Collections;
using UnityEngine;

public class HealAbility : BaseAbility
{
    public GameObject heal;

    public override void Activate()
    {
        StartCoroutine(HealAbilityCoroutine());
        IDamagable player = gameObject.GetComponent<IDamagable>();
        player.TakeDamage(-50);
    }

    IEnumerator HealAbilityCoroutine()
    {
        GameObject Heal = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(Heal);
    }
}
