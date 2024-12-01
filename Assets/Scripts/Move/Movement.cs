using UnityEngine;

namespace Move
{
    public abstract class Movement : MonoBehaviour
    {
        public abstract void Move(Vector2 dir, float speed);
    }
}