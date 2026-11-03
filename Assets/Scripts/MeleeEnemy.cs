using UnityEngine;

public class MeleeEnemy : BaseEnemy, IDamagable
{

    private EnemySword sword;

    protected override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        EnemySword sword = GetComponentInChildren<EnemySword>();
        sword.swing = canAttack;
    }
}
