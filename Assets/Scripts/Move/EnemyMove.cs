using UnityEngine;

namespace Move
{
    public class EnemyMove : Movement
    {
        public override void Move(Vector2 dir, float speed)
        {
            transform.Translate(dir * (speed * Time.deltaTime));
        }
    }
}