using Common;
using Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationLauncher : MonoBehaviour
    {
        [SerializeField] private PressedTimeCalculator _pressedTimeCalculator = null;
        [SerializeField] private AnimationPlayer _animationPlayer = null;
        [SerializeField] private FloorDetector _floorDetector = null;
        
        private void OnEnable()
        {
            _pressedTimeCalculator.NumberIncreased += OnPressedUp;
            _floorDetector.Grounded += OnFloorDetected;
        }

        private void OnDisable()
        {
            _pressedTimeCalculator.NumberIncreased -= OnPressedUp;
            _floorDetector.Grounded -= OnFloorDetected;
        }

        private void OnPressedUp()
        {
            _animationPlayer.PlayJumpUp();
        }

        private void OnFloorDetected()
        {
            _animationPlayer.PlayJumpDown();
        }
    }
}