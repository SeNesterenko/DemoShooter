using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationHandler))]
public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private float _runningSpeed;
    [SerializeField] private Transform _camera;
    
    private PlayerAnimationHandler _playerAnimationHandler;
    
    private void Awake()
    {
        _playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var isRunning = Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0;
        _playerAnimationHandler.SetRunMode(isRunning);

        if (!isRunning)
        {
            return;
        }
        
        var deltaAngle = MathF.Atan2(x, z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, _camera.rotation.eulerAngles.y + deltaAngle, 0);

        var movementDelta = Vector3.forward * _runningSpeed * Time.deltaTime;
        transform.Translate(movementDelta);
    }
}
