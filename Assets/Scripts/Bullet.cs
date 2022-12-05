using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 10;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime;
    

    public void Initialize(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        var otherHealth = other.gameObject.GetComponent<HealthHandler>();
        if (otherHealth != null && other.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            otherHealth.TakeDamage(_damage);
        }

        var effectHandler = other.gameObject.GetComponent<EffectHandler>();
        if (effectHandler != null)
        {
            for (var i = 0; i < other.contactCount; i++)
            {
                var contactPoint = other.contacts[i];
                effectHandler.ShowHitEffect(contactPoint.point, contactPoint.normal);
            }
        }
        
        Destroy(gameObject);
    }
}