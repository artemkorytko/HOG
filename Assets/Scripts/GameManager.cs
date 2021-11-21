using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_SAVE_KEY = "level_index";

    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private UIController uiController;
    
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
        Levels level = levelConfig.GetLevelByIndex(levelIndex);
        if (level != null)
        {
            InstantiateLevel(level);
        }
        
        uiController.InitializeLevel(_currentLevelInstance);
        uiController.OnLevelComplete += NextLevel;
    }

    private void NextLevel()
    {
        _currentLevel++;
        CurrentLevel = _currentLevel;
        CreateLevel(_currentLevel);
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
