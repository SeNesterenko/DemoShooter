using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private Player[] _listPlayer;
    
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        var saveManager = FindObjectOfType<SaveManager>();
        var indexPlayer = saveManager.LoadPlayer();
        var playerPosition = _listPlayer[indexPlayer].transform;
        _listPlayer[indexPlayer].gameObject.SetActive(true);

        var cameraController = FindObjectOfType<CameraController>();
        cameraController.Initialize(playerPosition);
        _enemyManager.Initialize(playerPosition.transform);
    }
}