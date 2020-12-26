using UnityEngine;

namespace Common
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _player = null;
        [SerializeField] private Vector3 _offset;
        [SerializeField] [Range(0, 1)] private float _smooth = 0.03f;

        void LateUpdate()
        {
            Fallowing();
        }

        private void Fallowing()
        {
            if(_player == null) return;
            
            Vector3 characterPosition = _player.position + _offset;
            transform.position = Vector3.Lerp(transform.position, characterPosition, _smooth);
        }
    }
}