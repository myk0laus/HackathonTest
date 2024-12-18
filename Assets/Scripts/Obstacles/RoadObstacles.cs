using System.Collections.Generic;
using UnityEngine;

public class RoadObstacles : MonoBehaviour
{
    [SerializeField] private Transform _vehicle;
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();
    [SerializeField] private float _minPosX, _maxPosX, _posY;

    [SerializeField] private float _minOffsetZ = 300, _maxOffsetZ = 550;
    private float _delay = 0.3f;
    private Obstacle _triggeredObstacle; 

    private void OnEnable()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.TriggeredObstacle += MarkTriggeredObstacles;
        }    
    }

    private void OnDisable()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.TriggeredObstacle -= MarkTriggeredObstacles;
        }
    }

    private void MarkTriggeredObstacles(Obstacle obstacle)
    {
        _triggeredObstacle = obstacle;       
        Invoke(nameof(SetPositionWithDelay), _delay);
    }

    private Vector3 GenerateNewVector()
    {
        Vector3 position = new Vector3(Random.Range(_minPosX, _maxPosX), _posY, Random.Range(_vehicle.position.z + _minOffsetZ, _vehicle.position.z + _maxOffsetZ));
        return position;       
    }

    private void SetPositionWithDelay()
    {
        Vector3 newPos = GenerateNewVector();
        _triggeredObstacle.ChangePosition(newPos);
    }
}