using System;
using UnityEngine;

namespace Player
{
    public class FloorDetector : MonoBehaviour
    {
        public event Action<Collider> Grounded = delegate { };
        public bool IsOnGround { get; set; } = true;

        private void OnTriggerEnter(Collider other)
        {
            IsOnGround = true;
            Grounded.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            IsOnGround = false;
        }
    }
}
