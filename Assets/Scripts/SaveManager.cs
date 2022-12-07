using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private ListPlayers _listPlayers;
    
    
    private string _dataPath;

    private void Awake()
    {
        _dataPath = Application.persistentDataPath + "MySaveData.dat";
    }

    public void SelectPlayer()
    {
        var index = _listPlayers.GetCurrentIndex();
        
        var binaryFormatter = new BinaryFormatter();
        var file = File.Create(_dataPath);

        var data = new SaveData
        {
            IndexPlayer = index
        };
        
        binaryFormatter.Serialize(file, data);
        file.Close();
        
        DontDestroyOnLoad(this);

        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public int LoadPlayer()
    {
        var index = 0;
        
        if (File.Exists(_dataPath))
        {
            var binaryFormatter = new BinaryFormatter();
            var file = File.Open(_dataPath, FileMode.Open);

            var data = (SaveData) binaryFormatter.Deserialize(file);
            index = data.IndexPlayer;
            
            file.Close();
        }

        return index;
    }
}