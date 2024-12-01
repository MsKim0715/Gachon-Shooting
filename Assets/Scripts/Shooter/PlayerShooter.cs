using Pooling;
using UnityEngine;
using BaseInput = InputData.BaseInput;

namespace Shooter
{
    public class PlayerShooter : Shooter
    {
        [SerializeField] private Transform muzzle;
        [SerializeField] private BaseInput shootingInput;


        private void Start()
        {
            shootingInput = GetComponent<BaseInput>();
            muzzle = transform.GetChild(0);
        }

        public override void Shoot(float delay, bool isShoot)
        {
            var isPress = shootingInput.ShootingInput();
            if (isPress && Time.time - LastShootTime >= delay && isShoot)
            {
                var obj = Pooler.Instance.GetObj("Bullet");
                obj.transform.position = muzzle.position;
                LastShootTime = Time.time;
            }
        }
    }
}