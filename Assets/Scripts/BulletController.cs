using UnityEngine;

public class BulletController : MonoBehaviour
{
      [SerializeField] private ParticleSystem onHitEffect;

      private float _damage;

      public void Init(float damage)
      {
            _damage = damage;
      }

      public float GetDamage()
      {
            return _damage;
      }

      private void OnTriggerEnter(Collider other)
      {
            onHitEffect.Play();
            onHitEffect.transform.SetParent(null);
      }
}
