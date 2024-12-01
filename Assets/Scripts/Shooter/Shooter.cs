using UnityEngine;

namespace Shooter
{
    public abstract class Shooter : MonoBehaviour
    {
        protected float LastShootTime;
        public abstract void Shoot(float delay, bool isShoot);
    }
}