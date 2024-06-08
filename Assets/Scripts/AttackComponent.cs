using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackComponent : MonoBehaviour
{
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackRate = 2f;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected Transform attackPoint;

    protected float nextAttackCooldown = 0f;

    protected Animator anim;

    public virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        InputAttack();
    }

    protected abstract void InputAttack();

    protected abstract void Attack();

}
