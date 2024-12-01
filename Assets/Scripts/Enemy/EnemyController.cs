using CollisionEvent;
using Data;
using Move;
using Pooling;
using UnityEngine;
using UseShooter = Shooter.Shooter;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IDamageable
    {
        [SerializeField] private Movement movement;
        [SerializeField] private EnemyStat enemyStat;
        [SerializeField] private UseShooter enemyShooter;
        public EnemyStat Enemy_Stat;
        private IDie _enemyDie;

        private void OnEnable()
        {
            movement = GetComponent<Movement>();
            enemyShooter = GetComponent<UseShooter>();
            Enemy_Stat = enemyStat.Clone() as EnemyStat;
            _enemyDie = GetComponent<IDie>();
        }

        private void Update()
        {
            movement?.Move(Vector2.down, Enemy_Stat.EnemySpeed);
            enemyShooter?.Shoot(Enemy_Stat.ShootDelay, Enemy_Stat.Isshoot);
            _enemyDie?.Die(Enemy_Stat.HP);
        }

        public void Damage(float damage)
        {
            Enemy_Stat.HP -= damage;
        }
        
        private void OnBecameInvisible()
        {
            Pooler.Instance.ReturnObj(gameObject);
        }
    }
}