using System;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public event Action Died;
    public event Action<float> GetDamage;

    [SerializeField] private float _startHealth;

    private float _currentHealth;
    private bool _isAlive => _currentHealth > 0;

    public float Initialize()
    {
        _currentHealth = _startHealth;
        
        return _currentHealth;
    }
    
    public void TakeDamage(int damage)
    {
        if (!_isAlive)
        {
            return;
        }
        
        _currentHealth -= damage;
        GetDamage?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}