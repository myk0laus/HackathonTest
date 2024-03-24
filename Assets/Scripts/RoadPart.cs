using System;
using UnityEngine;

public class RoadPart : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public event Action Triggered;
    public Transform SpawnPoint => _spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleController>())
        {
            Triggered?.Invoke();
        }
    }
}