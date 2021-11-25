using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_SAVE_KEY = "level_index";

    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private UiGameScreen uiGameScreen;

    private int currentLevel;
    private Level currentLevelInstance;

    private GameState gameState;
    private UiController uiController;
    public static GameManager Instance { get; private set; }

    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            if (gameState == value) return;

            gameState = value;

            switch (gameState)
            {
                case GameState.Start:
                    OnStartState();
                    break;
                case GameState.Game:
                    OnGameState();
                    break;
                case GameState.Win:
                    OnWinState();
                    break;
                default:
                    Debug.LogError("Wrong state");
                    break;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        uiController = FindObjectOfType<UiController>();
    }
    private void OnWinState()
    {
        
        uiController?.OnWinState();
    }

    private void OnGameState()
    {
        uiController?.OnGameState();
        currentLevel = CurrentLevel;
        CreateLevel(currentLevel);
    }

    private void OnStartState()
    {
        uiController?.OnStartState();
    }

    public void ChangeGameState(GameState state)
    {
        GameState = state;
    }

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
        GameState = GameState.Start;
    }

    private void CreateLevel(int level)
    {
        Level _level = levelConfig.GetLevelByIndex(level);
        if (_level != null)
        {
            InstantiateLevel(_level);
            uiGameScreen.Initialize(currentLevelInstance);
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
        currentLevelInstance.OnComplete += WinRound;
    }

    /**
     * TODO: Round number and next button screen
     */
    private void WinRound()
    {
        SaveGame();
        Debug.Log(CurrentLevel);
    }

    private void SaveGame()
    {
        currentLevel++;
        CurrentLevel = currentLevel;
    }
}
