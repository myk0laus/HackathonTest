using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Score _score;
    public event Action Dead;

    private void OnTriggerEnter(Collider other)
    { 
        if (other.GetComponent<Obstacle>())
        {
            _score.IncreaseScore();       
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<RoadPart>())
        {
            Dead?.Invoke();
        }
        if (collision.collider.GetComponent<Obstacle>())
        {
            Dead?.Invoke();
        }
    }
}