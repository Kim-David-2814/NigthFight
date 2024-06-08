using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHero3 : AttackComponent
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    //расчет кулдауна и анимация атаки
    protected override void InputAttack()
    {
        if (Time.time >= nextAttackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttackCooldown = Time.time + 1f / attackRate;
            }
        }
    }


    // проверка врага и нанесение урона
    protected override void Attack()
    {
        anim.SetTrigger("AttackHero3");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            HealthComponent health = enemy.GetComponent<HealthComponent>();

            if (health != null)
            {
                health.TakeDamageHero1(attackDamage);
            }
        }
    }


    // чтобы легче видететь где рассположен радиус атаки
    public void OnDrawGizmos()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawSphere(attackPoint.position, attackRange);
        }
    }

}
