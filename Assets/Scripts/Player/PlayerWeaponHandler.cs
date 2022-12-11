using UnityEngine;
using UnityEngine.Events;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _showAnimationShoot;
    [SerializeField] private UnityEvent<int> _setCountBullets;
    [SerializeField] private UnityEvent _weaponShot;
    
    
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private int _startCountBullets = 30;

    private int _currentCountBullets;

    private void Awake()
    {
        _setCountBullets.Invoke(_startCountBullets);
        _currentCountBullets = _startCountBullets;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currentCountBullets > 0)
        {
            _weaponShot.Invoke();
            _showAnimationShoot.Invoke();
            
            _playerWeapon.Shoot();

            _currentCountBullets--;
            _setCountBullets.Invoke(_currentCountBullets);
        }
    }
}