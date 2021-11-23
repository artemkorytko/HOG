using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_SAVE_KEY = "level_index";

    [SerializeField] private LevelConfig levelConfig;

    [Header("UI")]
    [SerializeField] private GameObject mainScreen = null;
    [SerializeField] private UiGameScreen gameScreen = null;
    [SerializeField] private GameObject winScreen = null;

    [Header("SOUNDS")]
    [SerializeField] private AudioClip[] audioClips;

    [Header("FX")]
    [SerializeField] private GameObject fx;

    private AudioSource audioSource;
    private int currentLevel;
    private Level currenLevelInstance;
   

    private void Awake()
    {
        InitializeUI();
        audioSource = GetComponent<AudioSource>();
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


    private void CreateLevel(int level)
    {
        Level _level = levelConfig.GetLevelByIndex(level);
        if(_level != null)
        {
            InstantiateLevel(_level);
        }
       
    }

    private void InstantiateLevel(Level level)
    {
        if(currenLevelInstance != null)
        {
            Destroy(currenLevelInstance.gameObject);
        }

        currenLevelInstance = Instantiate(level);
        currenLevelInstance.Initialize();
    }
    private void InitializeUI()
    {
        mainScreen.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        winScreen.SetActive(false);
    }
    public void StartGame()
    {
        mainScreen.SetActive(false);
        winScreen.SetActive(false);
        gameScreen.Initialize(currenLevelInstance);
        gameScreen.gameObject.SetActive(true);

        currenLevelInstance.OnComplete += StopGame;
        currenLevelInstance.OnItemListChanged += OnListChanged;
        fx.SetActive(false);
    }

    private void OnListChanged(string obj)
    {
        PlaySound(0);
    }

    private void StopGame()
    {
        PlaySound(1);
        gameScreen.gameObject.SetActive(false);
        winScreen.SetActive(true);
        //currentLevel++;
        CurrentLevel++;
        fx.SetActive(true);
    }
    public void StartNewGame()
    {
        currentLevel = CurrentLevel;
        CreateLevel(currentLevel);
        StartGame();
        
    }
    private void PlaySound(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
   
}
