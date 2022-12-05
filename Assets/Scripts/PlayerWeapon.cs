using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private ParticleSystem _muzzleEffect;
    
    public void Shoot()
    {
        var bullet = Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        bullet.Initialize(_muzzle.forward);
        _muzzleEffect.Play();
    }
}