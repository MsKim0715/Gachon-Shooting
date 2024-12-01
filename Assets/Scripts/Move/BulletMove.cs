using Pooling;
using UnityEngine;

namespace Move
{
    public class BulletMove : Movement
    {
        [SerializeField] private float maxRange;

        public override void Move(Vector2 dir, float speed)
        {
            transform.Translate(dir * (speed * Time.deltaTime));
            BulletLimitPosition();
        }

        private void BulletLimitPosition()
        {
            if (transform.position.y >= maxRange) Pooler.Instance.ReturnObj(gameObject);
        }
    }
}