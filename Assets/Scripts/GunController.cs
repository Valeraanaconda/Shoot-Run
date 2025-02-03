using Configs;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private float nexFireTime = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nexFireTime)
        {
            Shoot();
            nexFireTime = Time.time + _weaponConfig.fireRate;
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab).GetComponent<BulletController>();
        bullet.Init(_weaponConfig.damage);
        bullet.transform.position = firePoint.position;

        var rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * _weaponConfig.bulletSpeed;
        }
    }
}