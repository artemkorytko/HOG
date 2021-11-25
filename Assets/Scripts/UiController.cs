using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private UiStartPanel startPanel;
    private UiWinPanel winPanel;
    private UiGameScreen gameScreen;

    private BasePanel currentPanel;

    private void Awake()
    {
        startPanel = FindObjectOfType<UiStartPanel>(true);
        winPanel = FindObjectOfType<UiWinPanel>(true);
        gameScreen = FindObjectOfType<UiGameScreen>(true);
        currentPanel = null;
    }

    public void OnStartState()
    {
        currentPanel?.Close();
        startPanel.Open();
        currentPanel = startPanel;
    }

    public void OnGameState()
    {
        currentPanel?.Close();
        gameScreen.Open();
        currentPanel = gameScreen;
    }

    public void OnWinState()
    {
        currentPanel?.Close();
        winPanel.Open();
        currentPanel = winPanel;
    }
}