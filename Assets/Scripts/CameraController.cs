using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxPitch = 15;
    [SerializeField] private float _minPitch = -15;

    private Transform _target;
    private float _pitch;
    private float _yaw;

    public void Initialize(Transform target)
    {
        _target = target;
    }
    
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle > 360) angle -= 360;
        if (angle < -360) angle += 360;
        return Mathf.Clamp(angle, min, max);
    }

    private void LateUpdate()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");

        var yawDelta = x * _rotationSpeed * Time.deltaTime;
        var pitchDelta = -y * _rotationSpeed * Time.deltaTime;

        _pitch = ClampAngle(_pitch + pitchDelta, _minPitch, _maxPitch);
        _yaw += yawDelta;

        transform.position = _target.position;
        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0);
    }
}