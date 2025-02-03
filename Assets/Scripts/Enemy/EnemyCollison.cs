using UnityEngine;

public class EnemyCollison : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    public void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject.GetComponent<BulletController>();
        _enemy.TakeDamage(obj.GetDamage());
    }
}