using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    [SerializeField] private Transform _aimTarget;
    [SerializeField] private LayerMask _mask;
    
    private Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, 100, _mask))
        {
            _aimTarget.position = hitInfo.point;
        }
    }
}