using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy:MonoBehaviour
{
    [SerializeField] public float healthEnemy;
    [SerializeField] private float gunDamage = 0.1F;
    [SerializeField] public Image HealthBar;
    public event Action<float> OnDamageTaken;
    public void Start()
    {
        OnDamageTaken += TakeDamage;
    }
    public void TakeDamage(float damage)
    {
        healthEnemy -= damage;
        HealthBar.fillAmount = healthEnemy;
        if (healthEnemy <= 0) Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        OnDamageTaken?.Invoke(gunDamage);
    }
}
