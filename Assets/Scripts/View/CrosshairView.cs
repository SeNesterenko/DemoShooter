using UnityEngine;

public class CrosshairView : MonoBehaviour
{
    private Animator _animator;
    private static readonly int SingleShoot = Animator.StringToHash("SingleShoot");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetShootAnimation()
    {
        _animator.SetTrigger(SingleShoot);
    }
}