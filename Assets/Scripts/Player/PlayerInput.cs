using InputData;
using UnityEngine;

namespace Player
{
    public class PlayerInput : BaseInput
    {
        public override Vector2 GetMoveInput()
        {
            var moveInputData = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            return moveInputData;
        }

        public override bool ShootingInput()
        {
            var shootingInputData = Input.GetKey(KeyCode.Space);
            return shootingInputData;
        }
    }
}