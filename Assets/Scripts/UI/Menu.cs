using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headline;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _creditsButton.onClick.AddListener(OpenCredits);
        _closeButton.onClick.AddListener(CloseGame);
    }

    private void Start()
    {
        GameManager.GetInstance().NewGameState.AddListener(HandlePauseGameState);
    }

    private void HandlePauseGameState(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Pause)
            OpenPauseMenu();
    }

    private void StartGame()
    {
        Debug.Log("StartGame");
    }

    private void OpenCredits()
    {
        Debug.Log("OpenCredits");
    }

    private void CloseGame()
    {
        Debug.Log("CloseGame");
        Application.Quit();
    }

    private void OpenPauseMenu()
    {
        Debug.Log("PauseGame");
    }
}
