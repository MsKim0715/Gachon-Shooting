using UnityEngine;

namespace Move
{
    public class StopMove : Movement
    {
        [SerializeField] private float moveDuration;
        [SerializeField] private float stopDuration;
        [SerializeField] private bool isMoving = true;
        private float _stopTimer;


        public override void Move(Vector2 dir, float speed)
        {
            if (isMoving) transform.Translate(dir.normalized * (speed * Time.deltaTime));

            _stopTimer += Time.deltaTime;

            if (isMoving && _stopTimer >= moveDuration)
            {
                isMoving = false;
                _stopTimer = 0f;
            }
            else if (!isMoving && _stopTimer >= stopDuration)
            {
                isMoving = true;
                _stopTimer = 0f;
            }
        }
    }
}