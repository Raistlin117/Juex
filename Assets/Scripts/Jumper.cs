using UnityEngine;

namespace Player
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private FloorDetector _floorDetector = null;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _jumpUpMultiplier = 2;

        public void Jump(float jumpStrength)
        {
            if (!_floorDetector.IsOnGround) return;
            
            Vector3 force = transform.position + ((Vector3.up * _jumpUpMultiplier) + Vector3.forward) * jumpStrength;
            
            _rigidbody.AddForce(force, ForceMode.Acceleration);
        }
    }
}