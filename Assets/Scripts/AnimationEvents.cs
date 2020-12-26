using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class AnimationEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onJumpUp = null;

        public void OnJumpUp()
        {
            _onJumpUp?.Invoke();
        }
    }
}