using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private Player _player;

    private void Start()
    {
        _enemyManager.Initialize(_player.transform);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}