using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] public GameObject _plane; // панель победы игрока 

    // если игрок упадет за экран
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _plane.SetActive(true);
        }
    }
}
