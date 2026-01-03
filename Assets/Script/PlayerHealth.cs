using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float _maxHp;
    
    public float _currentHp;
    public Image _healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _maxHp = _currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.fillAmount = Mathf.Clamp(_currentHp / _maxHp, 0, 1);
        if (_currentHp == 0)
        {
            Destroy(gameObject);
        }
    }
}
