using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Collider _trigger;

    private const float _resetTime = 2f;

    public event Action Triggered;
    public event Action<Obstacle> TriggeredObstacle; 


    private void OnEnable()
    {
        Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        Triggered -= OnTriggered;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleController>())
        {
            _trigger.enabled = false;
            Triggered?.Invoke();
            TriggeredObstacle?.Invoke(this);
        }
    }
     
    private void OnTriggered()  
    { 
        Invoke(nameof(EnableTrigger), _resetTime);
    }

    private void EnableTrigger()
    {
        _trigger.enabled = true;
        Debug.Log($"{gameObject.name} Enabled again");
    }

    public void ChangePosition(Vector3 position)
    {
        transform.position = position;  
    }
}