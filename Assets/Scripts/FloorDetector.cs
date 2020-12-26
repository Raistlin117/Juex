using System;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    public event Action Grounded = delegate { };
    public bool IsOnGround { get; set; } = true;

    private void OnTriggerEnter(Collider other)
    {
        IsOnGround = true;
        Grounded.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        IsOnGround = false;
    }
}
