using UnityEngine;

namespace Move
{
    public class PlayerMove : Movement
    {
        [SerializeField] private float posLimitX;
        [SerializeField] private float posLimitY;

        public override void Move(Vector2 dir, float speed)
        {
            transform.Translate(dir.normalized * (speed * Time.deltaTime));
            PlayerLimitPosition();
        }

        private void PlayerLimitPosition()
        {
            var myPos = new Vector2(Mathf.Clamp(transform.position.x, -posLimitX, posLimitX), 
            Mathf.Clamp(transform.position.y, -posLimitY, posLimitY));
            transform.position = myPos;
        }
        
    }
}