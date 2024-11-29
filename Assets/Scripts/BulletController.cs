using UnityEngine;

public class BulletController : MonoBehaviour
{
      [SerializeField] private ParticleSystem onHitEffect;

      private void OnTriggerEnter(Collider other)
      {
            onHitEffect.Play();
            onHitEffect.transform.SetParent(null);
      }
}
