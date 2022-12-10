using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _startHealth;

    public void Initialize(float startHealth)
    {
        _startHealth = startHealth;
    }

    public void ChangeHealthBar(float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / _startHealth;
    }
}