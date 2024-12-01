using CollisionEvent;
using Data;
using Move;
using Pooling;
using UnityEngine;

namespace Projectile.Missile
{
    public class MissileController : MonoBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private MissileStat missileStat;
        private MissileStat Missile_Stat;

        private void Start()
        {
            movement = GetComponent<Movement>();
            Missile_Stat = missileStat.Clone() as MissileStat;
        }

        private void Update()
        {
            movement.Move(Vector2.down, Missile_Stat.MissileSpeed);
        }

        private void OnBecameInvisible()
        {
            Pooler.Instance.ReturnObj(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var damage = other.GetComponent<IDamageable>();
                damage?.Damage(Missile_Stat.MissileDamage);
            }
        }
    }
}