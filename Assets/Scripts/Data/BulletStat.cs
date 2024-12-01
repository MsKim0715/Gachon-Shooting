using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Bullet Stat", menuName = "Scriptable Object/Bullet Stat")]
    public class BulletStat : ScriptableObject, ICloneable
    {
        [SerializeField] private float bulletSpeed;

        [SerializeField] private float bulletDamage;

        public float BulletSpeed
        {
            get => bulletSpeed;
            set => bulletSpeed = value;
        }

        public float BulletDamage
        {
            get => bulletDamage;
            set => bulletDamage = value;
        }

        public object Clone()
        {
            return Instantiate(this);
        }
    }
}