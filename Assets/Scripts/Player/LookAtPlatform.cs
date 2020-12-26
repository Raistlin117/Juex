using DG.Tweening;
using Platform;
using UnityEngine;

namespace Player
{
    public class LookAtPlatform : MonoBehaviour
    {
        [SerializeField] private FloorDetector _floorDetector = null;
        [SerializeField] private Transform[] _platforms = null;
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private Vector3 _offset;

        private void OnEnable()
        {
            _floorDetector.Grounded += OnGrounded;
        }

        private void OnDisable()
        {
            _floorDetector.Grounded -= OnGrounded;
        }

        private void OnGrounded(Collider currentPlatformCollider)
        {
            int index = currentPlatformCollider.GetComponent<PlatformIndex>().Index;
            
            Look(index + 1);
        }

        private void Look(int index)
        {
            transform.DOLookAt(_platforms[index].position + _offset, _duration);
        }
    }
}