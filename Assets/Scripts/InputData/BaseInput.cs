using UnityEngine;

namespace InputData
{
    public abstract class BaseInput : MonoBehaviour
    {
        public abstract Vector2 GetMoveInput();
        public abstract bool ShootingInput();
    }
}