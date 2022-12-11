using UnityEngine;

[RequireComponent(typeof(PlayerMovementHandler))]
[RequireComponent(typeof(HealthHandler))]
[RequireComponent(typeof(PlayerAnimationHandler))]
[RequireComponent(typeof(PlayerAimController))]
[RequireComponent(typeof(HealthBarView))]
public class Player : MonoBehaviour
{
    private PlayerMovementHandler _movementHandler;
    private HealthHandler _healthHandler;
    private PlayerAnimationHandler _animationHandler;
    private PlayerAimController _playerAimController;
    private HealthBarView _healthBarView;
    
    private void Awake()
    {
        _movementHandler = GetComponent<PlayerMovementHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _animationHandler = GetComponent<PlayerAnimationHandler>();
        _playerAimController = GetComponent<PlayerAimController>();
        _healthBarView = GetComponent<HealthBarView>();
        
        var startHealth = _healthHandler.Initialize();
        _healthBarView.Initialize(startHealth);
        
        _healthHandler.GetDamage += _healthBarView.ChangeHealthBar;
        _healthHandler.Died += OnDied;
    }

    private void OnDied()
    {
        _animationHandler.PlayDieAnimation();
        
        _movementHandler.enabled = false;
        _playerAimController.enabled = false;
    }

    private void OnDestroy()
    {
        if (_healthHandler == null) return;
        
        _healthHandler.Died -= OnDied;
        _healthHandler.GetDamage -= _healthBarView.ChangeHealthBar;
    }
}