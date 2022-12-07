using UnityEngine;

public class ListPlayers : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    [SerializeField] private float _rotationSpeed;
    
    private int _index;
    private Player _currentPlayer;
    
    private void Awake()
    {
        ShowPlayer(0);
        _currentPlayer = _players[0];
    }

    private void LateUpdate()
    {
        var step = Time.deltaTime * _rotationSpeed;
        
        _currentPlayer.transform.Rotate(Vector3.up * step);
    }

    public int GetCurrentIndex()
    {
        return _index;
    }
    
    public void ShowNextPlayer()
    {
        var previousIndex = _index;
        _index = (_index + 1) % _players.Length;
        ShowPlayer(_index, previousIndex);
    }

    public void ShowPreviousPlayer()
    {
        var previousIndex = _index;
        _index = (_index - 1 + _players.Length) % _players.Length;
        ShowPlayer(_index, previousIndex);
    }
    
    private void ShowPlayer(int currentIndex, int previousIndex)
    {
        _players[previousIndex].gameObject.SetActive(false);
        _players[currentIndex].gameObject.SetActive(true);
        _currentPlayer = _players[currentIndex];
    }

    private void ShowPlayer(int index)
    {
        _players[index].gameObject.SetActive(true);
    }
}