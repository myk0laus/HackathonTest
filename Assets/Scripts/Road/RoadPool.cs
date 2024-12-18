using UnityEngine;

public class RoadPool : MonoBehaviour
{
    [SerializeField] private RoadPart _roadPart1;
    [SerializeField] private RoadPart _roadPart2;

    private void OnEnable()
    {
        _roadPart1.Triggered += OnTriggeredPart1;
        _roadPart2.Triggered += OnTriggeredPart2;
    }

    private void OnTriggeredPart1()
    {
        _roadPart2.transform.position = _roadPart1.SpawnPoint.position;
    } 

    private void OnTriggeredPart2() 
    {
        _roadPart1.transform.position = _roadPart2.SpawnPoint.position;
    }    
}