using UnityEngine;

[RequireComponent(typeof(EnemyAnimationHandler))]
public class EnemyAttackController : MonoBehaviour
{
    private EnemyAnimationHandler _enemyAnimationHandler;
    private bool _isAttack;

    private void Awake()
    {
        _enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
    }

    public void AttackTarget(bool isAttack)
    {
        _enemyAnimationHandler.SetAttackMode(isAttack);
    }
}