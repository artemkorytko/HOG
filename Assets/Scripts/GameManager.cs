using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_SAVE_KEY = "level_index";

    [SerializeField] private LevelConfig levelConfig;

    private int currentLevel;
    private Level currentLevelInstance;

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
        currentLevel = CurrentLevel;
        CreateLevel(currentLevel);
    }

    private void CreateLevel(int level)
    {
        Level _level = levelConfig.GetLevelByIndex(level);
        if (_level != null)
        {
            InstantiateLevel(_level);
        }
    }

    private void InstantiateLevel(Level level)
    {
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance.gameObject);
        }

        currentLevelInstance = Instantiate(level);
        currentLevelInstance.Initialize();
    }
}
