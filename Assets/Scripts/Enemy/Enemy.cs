using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;
    
    [SerializeField] private HealthHandler _healthHandler;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _shootingRange = 5;
    [SerializeField] private EnemyAttackController _enemyAttackController;
    
    private Transform _target;

    public void Initialize(Transform target)
    {
        _target = target;
        MoveToShootingRange(target);

        _healthHandler.Initialize();
    }

    private void Update()
    {
        MoveToShootingRange(_target);
    }

    private void MoveToShootingRange(Transform target)
    {
        var distanceToTarget = Vector3.Distance(transform.position, target.position);
        var shootingDistance = Mathf.Max(0, distanceToTarget - _shootingRange);
        var directionToTarget = (target.position - transform.position).normalized;
        var destination = transform.position + shootingDistance * directionToTarget;

        _navMeshAgent.destination = destination;

        var isAttacking = shootingDistance <= 0;
        _enemyAttackController.AttackTarget(isAttacking);
    }

    private void Start()
    {
        _healthHandler.Died += OnDied;
    }

    private void OnDestroy()
    {
        _healthHandler.Died -= OnDied;
    }

    private void OnDied()
    {
        var enemy = GetComponent<Enemy>();
        Died?.Invoke(enemy);
        Destroy(gameObject);
    }
}