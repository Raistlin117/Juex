using Common;
using Player;
using UnityEngine;

namespace Animations
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

        private void OnFloorDetected(Collider collider)
        {
            _animationPlayer.PlayJumpDown();
        }
    }
}