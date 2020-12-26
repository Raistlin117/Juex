using UnityEngine;

namespace Animations
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private string _jumpUp = string.Empty;
        [SerializeField] private string _jumpDown = string.Empty;
        [SerializeField] private string _victory = string.Empty;

        private int _jumpUpIndex = 0;
        private int _jumpDownIndex = 0;
        private int _victoryIndex = 0;

        private void Awake()
        {
            _jumpUpIndex = Animator.StringToHash(_jumpUp);
            _jumpDownIndex = Animator.StringToHash(_jumpDown);
            _victoryIndex = Animator.StringToHash(_victory);
        }

        public void PlayJumpUp()
        {
            _animator.Play(_jumpUpIndex);
        }

        public void PlayJumpDown()
        {
            _animator.Play(_jumpDownIndex);
        }

        private void PlayVictory()
        {
            _animator.Play(_victoryIndex);
        }
    }
}