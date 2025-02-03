using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healthEnemy;
    [SerializeField] private Image _healthBar;

    private float _maxHealth;

    public void Start()
    {
        _maxHealth = _healthEnemy;
    }

    public void TakeDamage(float damage)
    {
        _healthEnemy -= damage;
        _healthBar.fillAmount = _healthEnemy / _maxHealth;
        
        if (_healthEnemy <= 0) 
            Destroy(gameObject);
    }
}