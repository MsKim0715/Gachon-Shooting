using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Player Stat", menuName = "Scriptable Object/Player Stat")]
    public class PlayerStat : ScriptableObject, ICloneable
    {
        [SerializeField] private float playerSpeed;

        [SerializeField] private float shootDelay;

        [SerializeField] private float hp;
        [SerializeField] private bool isShoot;

        public float PlayerSpeed
        {
            get => playerSpeed;
            set => playerSpeed = value;
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

        public bool IsShoot
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