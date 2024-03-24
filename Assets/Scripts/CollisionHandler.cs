using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private LayerMask _borderMask;
    [SerializeField] private float _checkingDistance;
    [SerializeField] private float _maxCheckingTime;
    private float _currentCheckingTime;

    public event Action Dead;

    private void Start()
    {
        _currentCheckingTime = _maxCheckingTime;
    }

    private void Update()
    {
        BorderCheck();
    }

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

    private void BorderCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, _checkingDistance, _borderMask))
        {
            Debug.Log("I see border");
            _currentCheckingTime -= Time.deltaTime;
            if (_currentCheckingTime <= 0)
                Dead?.Invoke();
        }
        else
        {
            _currentCheckingTime = _maxCheckingTime;
            return;
        }
    }
}