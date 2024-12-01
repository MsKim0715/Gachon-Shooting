using CollisionEvent;
using Data;
using Move;
using UnityEngine;

namespace Projectile.Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private BulletStat bulletStat;
        private BulletStat Bullet_Stat;

        private void Start()
        {
            movement = GetComponent<Movement>();
            Bullet_Stat = bulletStat.Clone() as BulletStat;
        }

        private void Update()
        {
            movement?.Move(Vector2.up, Bullet_Stat.BulletSpeed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                return;
            }
            
            if (other.TryGetComponent(out IDamageable damage))
            {
                damage?.Damage(Bullet_Stat.BulletDamage);
            }
        }
    }
}