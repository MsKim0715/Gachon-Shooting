using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Enemy Stat", menuName = "Scriptable Object/Enemy Stat")]
    public class EnemyStat : ScriptableObject, ICloneable
    {
        [SerializeField] private float enemySpeed;

        [SerializeField] private float shootDelay;

        [SerializeField] private float hp;
        [SerializeField] private bool isShoot;

        public float EnemySpeed
        {
            get => enemySpeed;
            set => enemySpeed = value;
        }

        public float ShootDelay
        {
            get => shootDelay;
            set => shootDelay = value;
        }


        public float HP
        {
            get => hp;
            set => hp = value;
        }

        public bool Isshoot
        {
            get => isShoot;
            set => isShoot = value;
        }

        public object Clone()
        {
            return Instantiate(this);
        }
    }
}