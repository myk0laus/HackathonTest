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

    private float _currentAcceleration = 0f;
    private float _currentTurnAngle = 0f;
    [SerializeField] private float _turnStep;

    private bool _leftTurn;
    private bool _rightTurn;
    private bool _noTurn;

    private void Update()
    {
        Debug.Log(_currentTurnAngle);
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

        //_currentTurnAngle = Input.GetAxis("Horizontal") * _maxTurnAngle;

        if (_leftTurn && _currentTurnAngle > -_maxTurnAngle)
            _currentTurnAngle -= _turnStep * Time.deltaTime;
        if (_rightTurn && _currentTurnAngle < _maxTurnAngle)
            _currentTurnAngle += _turnStep * Time.deltaTime;
        if (_noTurn)
            _currentTurnAngle = 0;
    }

    public void OnTurnLeftButtonPressed()
    {
        _noTurn = false;
        _rightTurn = false;
        _leftTurn = true;
    }

    public void OnTurnRightButtonPressed()
    {
        _noTurn = false;
        _rightTurn = true;
        _leftTurn = false;
    }

    public void OnTurnButtonReleased()
    {
        _noTurn = true;
        _rightTurn = false;
        _leftTurn = false;
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