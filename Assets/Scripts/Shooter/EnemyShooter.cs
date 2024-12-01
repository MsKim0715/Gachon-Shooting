using Pooling;
using UnityEngine;

namespace Shooter
{
    public class EnemyShooter : Shooter
    {
        [SerializeField] private Transform muzzle;


        private void Start()
        {
            muzzle = transform.GetChild(0);
        }

        public override void Shoot(float delay, bool isShoot)
        {
            if (Time.time - LastShootTime >= delay && isShoot)
            {
                var obj = Pooler.Instance.GetObj("Missile");
                obj.transform.position = muzzle.position;
                LastShootTime = Time.time;
            }
        }
    }
}