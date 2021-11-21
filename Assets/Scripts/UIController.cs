using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Action OnLevelComplete;
    
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private UIGameScreen _gameScreen;


    private void Start()
    {
        
        _menuPanel?.SetActive(true);
        _winPanel?.SetActive(false);
        _gameScreen?.gameObject.SetActive(false);
    }

    public void InitializeLevel(Levels level)
    {
        _gameScreen.Initialize(level);
        level.OnComplete += LevelComplete;
    }

    private void LevelComplete()
    {
        _gameScreen?.gameObject.SetActive(false);
        _winPanel?.SetActive(true);
        OnLevelComplete?.Invoke();
    }

    public void PlayButton()
    {
        _menuPanel?.SetActive(false);
        _gameScreen?.gameObject.SetActive(true);
        _winPanel?.SetActive(false);
    }

    public void MenuButton()
    {
        _menuPanel?.SetActive(true);
        _gameScreen?.gameObject.SetActive(false);
        _winPanel?.SetActive(false);
    }
}
