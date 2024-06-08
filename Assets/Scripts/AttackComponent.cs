using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackComponent : MonoBehaviour
{
    [SerializeField] protected float attackRange;     //радиус атаки
    [SerializeField] protected float attackRate = 2f; //кулдаун атаки
    [SerializeField] protected int attackDamage;      //урон
    [SerializeField] protected LayerMask enemyLayer;  //слой врага
    [SerializeField] protected Transform attackPoint; //точк радиуса атаки

    protected float nextAttackCooldown = 0f; // время для следущей атаки

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
