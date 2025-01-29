using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nexFireTime = 0f;
    [SerializeField] public float damage;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nexFireTime)
        {
            Shoot();
            nexFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;

        var rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}