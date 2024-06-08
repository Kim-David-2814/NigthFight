using NightFight.input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _startingHealthHero1; // стартовые жизни игрока 1
    [SerializeField] private float _startingHealthHero3; // стартовые жизни игрока 2 

    public GameObject _win; //панель победы

    public float _currentHealthHero3 { get; private set; }
    public float _currentHealthHero1 { get; private set; }

    private Animator _anim;
    private bool _isDeadHero1; // мерт герой или нет
    private bool _isDeadHero3; 


    private void Awake()
    {
        _currentHealthHero1 = _startingHealthHero1;
        _currentHealthHero3 = _startingHealthHero3;
        _anim = GetComponent<Animator>();
    }

    // получение урона игроком 
    public void TakeDamageHero1(float damage)
    {
        _currentHealthHero1 = Mathf.Clamp(_currentHealthHero1 - damage, 0, _startingHealthHero1);

        if (_currentHealthHero1 > 0)
        {
            _anim.SetTrigger("HitHero1");
        }
        else
        {
            if (!_isDeadHero1)
            {
                _anim.SetTrigger("DeadHero1");
               
                _win.SetActive(true);

                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().enabled = false;
                }
                if (GetComponent<PlayerAttackHero1>() != null)
                {
                    GetComponent<PlayerAttackHero1>().enabled = false;
                }

                _isDeadHero1 = true;
            }
        }
    }

    public void TakeDamageHero3(float damage)
    {
        _currentHealthHero3 = Mathf.Clamp(_currentHealthHero3 - damage, 0, _startingHealthHero3);

        if (_currentHealthHero3 > 0)
        {
            _anim.SetTrigger("HitHero3");
        }
        else
        {
            if (!_isDeadHero3)
            {
                _anim.SetBool("DeadHero3", true);
                
                _win.SetActive(true);

                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().enabled = false;
                }
                if (GetComponent<PlayerAttackHero3>() != null)
                {
                    GetComponent<PlayerAttackHero3>().enabled = false;
                }

                _isDeadHero3 = true;
            }
        }
    }
}
