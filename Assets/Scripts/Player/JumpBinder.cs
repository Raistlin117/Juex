using Common;
using UnityEngine;

namespace Player
{
    public class JumpBinder : MonoBehaviour
    {
        [SerializeField] private Jumper _jumper = null;
        [SerializeField] private PressedTimeCalculator _pressedTime = null;

        /// <summary>
        /// Launched from JumpUp animation
        /// </summary>
        /// <param name="jumpStrength"></param>
        public void Jump()
        {
            _jumper.Jump(_pressedTime.GetIncreasedNumber());
        }
    }
}