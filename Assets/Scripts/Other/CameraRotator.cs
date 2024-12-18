using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.RotateAround(_target.position, Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}