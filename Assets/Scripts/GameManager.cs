using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private List<Level> _allLevels = null;

    [Header("UI")]
    [SerializeField] private GameObject _mainScreen = null;
    [SerializeField] private UIGameScreen _gameScreen = null;
    [SerializeField] private GameObject _winScreen = null;

    private Level _currentLevel = null;
    private int _currentLevelIndex = 0;

    public int LevelIndex => _currentLevelIndex + 1;
    public Level Level => _currentLevel;

    private void Awake()
    {
        LoadData();
        CreateLevel();
        InitializeUI();
    }

    private void LoadData()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0);
    }

    private void CreateLevel()
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex);
        _currentLevel.Initialize();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex);
    }

    private Level InstantiateLevel(int index)
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }

        if (index >= _allLevels.Count)
        {
            index = index % _allLevels.Count;
        }

        return Instantiate(_allLevels[index].gameObject, transform).GetComponent<Level>(); ;
    }

    private void InitializeUI()
    {
        _mainScreen.SetActive(true);
        _gameScreen.gameObject.SetActive(false);
        _winScreen.SetActive(false);
    }

    public void StartGame()
    {
        _mainScreen.SetActive(false);
        _winScreen.SetActive(false);
        _gameScreen.Initialize(_currentLevel);
        _gameScreen.gameObject.SetActive(true);

        _currentLevel.OnComplete += StopGame;
    }

    private void StopGame()
    {
        _gameScreen.gameObject.SetActive(false);
        _winScreen.SetActive(true);

        _currentLevelIndex++;
        SaveData();
    }

    public void StartNewGame()
    {
        CreateLevel();
        StartGame();
    }
}
