using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsAttack = Animator.StringToHash("IsAttack");

    public void SetAttackMode(bool isAttack)
    {
        _animator.SetBool(IsAttack, isAttack);
    }
}