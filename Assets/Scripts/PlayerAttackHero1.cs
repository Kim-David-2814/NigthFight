using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHero1 : AttackComponent
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void InputAttack()
    {
        if (Time.time >= nextAttackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackCooldown = Time.time + 1f / attackRate;
            }
        }
    }

    protected override void Attack()
    {
        anim.SetTrigger("AttackHero1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            HealthComponent health = enemy.GetComponent<HealthComponent>();

            if (health != null)
            {
                health.TakeDamageHero3(attackDamage);
            }
        }
    }

    public void OnDrawGizmos()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawSphere(attackPoint.position, attackRange);
        }
    }

}
