using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private LayerMask _borderMask;
    [SerializeField] private float _checkingDistance;
    [SerializeField] private float _maxCheckingTime;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _crashClip;
    [SerializeField] private AudioClip _collectObstacleClip;
    private float _currentCheckingTime;
    private bool _collided = false;

    public Score Score => _score;

    public event Action Dead;
    public bool Collided
    {
        get => _collided;
        set => _collided = value;
    }

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
            _audioSource.PlayOneShot(_collectObstacleClip);
            _score.IncreaseScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_collided == false)
        {
            if (collision.collider.GetComponent<RoadPart>())
            {
                _audioSource.PlayOneShot(_crashClip);
                Dead?.Invoke();
                _collided = true;
                Debug.Log("Dead invoked");
            }
            else if (collision.collider.GetComponent<Obstacle>())
            {
                _audioSource.PlayOneShot(_crashClip);
                Dead?.Invoke();
                _collided = true;

                Debug.Log("Dead invoked");
            }
        }
    }

    private void BorderCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, _checkingDistance, _borderMask))
        {
            Debug.Log("I see border");
            _currentCheckingTime -= Time.deltaTime;
            if (_currentCheckingTime <= 0)
            {
                Dead?.Invoke();
                Debug.Log("Dead invoked");
            }
        }
        else
        {
            _currentCheckingTime = _maxCheckingTime;
            return;
        }
    }
}