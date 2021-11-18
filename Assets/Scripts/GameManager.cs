using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_SAVE_KEY = "level_index";

    [SerializeField] private LevelConfig _levelConfig;
    
    private int _currentLevel;
    private Levels _currentLevelInstance;
    
    public int CurrentLevel
    {
        get
        {
            return PlayerPrefs.GetInt(LEVEL_SAVE_KEY, 0);
        }
        set
        {
            PlayerPrefs.SetInt(LEVEL_SAVE_KEY, value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        _currentLevel = CurrentLevel;
        CreateLevel(_currentLevel);
    }

    private void CreateLevel(int levelIndex)
    {
        Levels level = _levelConfig.GetLevelByIndex(levelIndex);
        if (level != null)
        {
            InstantiateLevel(level);
        }
    }

    private void InstantiateLevel(Levels level)
    {
        if (_currentLevelInstance != null)
        {
            Destroy(_currentLevelInstance.gameObject);
        }

        _currentLevelInstance = Instantiate(level);
        _currentLevelInstance.Initialize();
    }
}
