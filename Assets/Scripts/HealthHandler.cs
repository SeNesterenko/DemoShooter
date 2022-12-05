using System;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    private bool _isAlive => _currentHealth > 0;
    public event Action Died;
    public event Action<float> GetDamage;

    [SerializeField] private float _startHealth;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }
    
    public float GetCurrentHealth()
    {
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