using Player;
using UnityEngine;
using Input = Juex.Input.Input;

namespace DefaultNamespace
{
    public class AnimationLauncher : MonoBehaviour
    {
        [SerializeField] private Input _input = null;
        [SerializeField] private AnimationPlayer _animationPlayer = null;
        [SerializeField] private FloorDetector _floorDetector = null;

        private bool _firstTime = true;

        private void OnEnable()
        {
            _input.PressedUp += OnPressedUp;
            _floorDetector.Grounded += OnFloorDetected;
        }

        private void OnDisable()
        {
            _input.PressedUp -= OnPressedUp;
            _floorDetector.Grounded -= OnFloorDetected;
        }

        private void OnPressedUp()
        {
            _animationPlayer.PlayJumpUp();
        }

        private void OnFloorDetected()
        {
            if (_firstTime)
            {
                _firstTime = false;
                return;
            }
            
            _animationPlayer.PlayJumpDown();
        }
    }
}