using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent _playerHealthHero1;
    [SerializeField] private HealthComponent _playerHealthHero3;
    [SerializeField] private Image _totalHealtBarHero1;
    [SerializeField] private Image _currentHealthBarHero1;
    [SerializeField] private Image _totalHealtBarHero3;
    [SerializeField] private Image _currentHealthBarHero3;

    private void Start()
    {
        _totalHealtBarHero1.fillAmount = _playerHealthHero1._currentHealthHero1 / 10;
        _totalHealtBarHero3.fillAmount = _playerHealthHero3._currentHealthHero3 / 10;
    }

    private void Update()
    {
        UpdateHeatlh();
    }

    public void UpdateHeatlh()
    {
        _currentHealthBarHero1.fillAmount = _playerHealthHero1._currentHealthHero1 / 10;
        _currentHealthBarHero3.fillAmount = _playerHealthHero3._currentHealthHero3 / 10;
    }
}
