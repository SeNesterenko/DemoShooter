using UnityEngine;

public class EnemyWeaponHandler : MonoBehaviour
{
    [SerializeField] private int _damage = 30;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            var healthHandler = collision.gameObject.GetComponent<HealthHandler>();
            healthHandler.TakeDamage(_damage);
        }
    }
}