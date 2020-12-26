using System;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    public event Action Defeated = delegate { };
    
    [SerializeField] private Transform _playerStartTransform = null;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

        other.transform.position = _playerStartTransform.position;

        Defeated.Invoke();
    }
}
