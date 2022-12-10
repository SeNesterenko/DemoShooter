using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemyView : MonoBehaviour
{
    [SerializeField] private Image _enemyIcon;
    
    private RectTransform _enemiesView;
    private Stack<Image> _enemyIcons;

    public void Initialize(int enemiesCount)
    {
        _enemiesView = GetComponent<RectTransform>();
        _enemyIcons = new Stack<Image>();

        for (var i = 0; i < enemiesCount; i++)
        {
            var icon = Instantiate(_enemyIcon, _enemiesView);
            _enemyIcons.Push(icon);
        }
    }

    public void OnEnemyDied()
    {
        Destroy(_enemyIcons.Pop());
    }
}