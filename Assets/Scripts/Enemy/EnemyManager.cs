using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _radius = 5;
    [SerializeField] private int _enemiesCount = 5;
    [SerializeField] private CountEnemyView _countEnemyView;
    [SerializeField] private AudioSource _mouseDeathSound;
    

    private List<Enemy> _enemies;
    public void Initialize(Transform enemiesTarget)
    {
        _enemies = new List<Enemy>();
        _countEnemyView.Initialize(_enemiesCount);
        
        for (var i = 0; i < _enemiesCount; i++)
        {
            var enemy = Instantiate(_enemyPrefab);

            var randomPosition = _spawnPosition.transform.position + Random.insideUnitSphere * _radius;
            randomPosition.y = 0;
            enemy.transform.position = randomPosition;
            
            enemy.Initialize(enemiesTarget);
            enemy.Died += OnEnemyDied;
            _enemies.Add(enemy);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _mouseDeathSound.Play();
        _countEnemyView.OnEnemyDied();
        enemy.Died -= OnEnemyDied;
    }
}