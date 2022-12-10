using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int DieTrigger = Animator.StringToHash("Die");
    private static readonly int SingleShoot = Animator.StringToHash("SingleShoot");

    public void SetRunMode(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }

    public void PlayDieAnimation()
    {
        _animator.SetTrigger(DieTrigger);
    }

    public void PlaySingleShootAnimation()
    {
        _animator.SetTrigger(SingleShoot);
    }
}