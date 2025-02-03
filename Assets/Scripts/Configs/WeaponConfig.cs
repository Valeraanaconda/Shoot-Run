using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WeaponConfig",menuName = "Configs/WeaponConfig",order = 1)]
    public class WeaponConfig : ScriptableObject
    {
        public WeaponType WeaponType;
        public float bulletSpeed;
        public float fireRate;
        public float damage;
    }
}