using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWinPanel : BasePanel
{
    private Button menuButton;

    public override void Open()
    {
        base.Open();
    }

    private void Awake()
    {
        menuButton = GetComponentInChildren<Button>(true);
    }

    private void Start()
    {
        menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDestroy()
    {
        menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnMenuButtonClick()
    {
        GameManager.Instance.ChangeGameState(GameState.Game);
    }
}
