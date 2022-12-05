using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private float _hitEffectDuration = 3;
    
    public void ShowHitEffect(Vector3 hitPosition, Vector3 normal)
    {
        var hitEffect = Instantiate(_hitEffect, hitPosition, Quaternion.LookRotation(normal));
        hitEffect.Play();

        Destroy(hitEffect, _hitEffectDuration);
    }
}