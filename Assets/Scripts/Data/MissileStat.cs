using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Missile Stat", menuName = "Scriptable Object/Missile Stat")]
    public class MissileStat : ScriptableObject, ICloneable
    {
        [SerializeField] private float missileSpeed;

        [SerializeField] private float bulletDamage;

        public float MissileSpeed
        {
            get => missileSpeed;
            set => missileSpeed = value;
        }

        public float MissileDamage
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