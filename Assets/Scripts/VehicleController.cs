using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private WheelCollider _frontRight;
    [SerializeField] private WheelCollider _frontLeft;
    [SerializeField] private WheelCollider _backRight;
    [SerializeField] private WheelCollider _backLeft;

    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxTurnAngle;

    [SerializeField] private Transform _frontRightTransform;
    [SerializeField] private Transform _frontLeftTransform;
    [SerializeField] private Transform _backRightTransform;
    [SerializeField] private Transform _backLeftTransform;

    private float _currentAcceleration = 0;
    private float _currentTurnAngle = 0;


    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        DriveVehicle();
        WheelTurn();
    }

    private void CheckInput()
    {
        _currentAcceleration = _acceleration;

        _currentTurnAngle = Input.GetAxis("Horizontal") * _maxTurnAngle;

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                _currentTurnAngle = -1 * _maxTurnAngle;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                _currentTurnAngle = 1 * _maxTurnAngle;
            }
        }

    }

    private void DriveVehicle()
    {
        _frontRight.motorTorque = _currentAcceleration;
        _frontLeft.motorTorque = _currentAcceleration;
    }

    private void WheelTurn()
    {
        _frontLeft.steerAngle = _currentTurnAngle;
        _frontRight.steerAngle = _currentTurnAngle;

        UpdateTransform(_frontLeft, _frontLeftTransform);
        UpdateTransform(_frontRight, _frontRightTransform);
        UpdateTransform(_backLeft, _backLeftTransform);
        UpdateTransform(_backRight, _backRightTransform);
    }

    private void UpdateTransform(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}