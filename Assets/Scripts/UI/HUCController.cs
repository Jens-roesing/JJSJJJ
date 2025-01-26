using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUCController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private Image _o2Bar;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        GameManager.GetInstance().NewGameState.AddListener(HandleGameState);
    }

    private void HandleGameState(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Playing)
            _container.SetActive(true);

        if (state == GameManager.GameState.Pause || state == GameManager.GameState.Win || state == GameManager.GameState.Lose)
            _container.SetActive(false);
    }

    private void Update()
    {
        var ts = TimeSpan.FromSeconds(GameManager.MAX_GAMETIME - GameManager.GetInstance().Timer);
        _timer.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);

        UpdateO2UI();
    }

    private void UpdateO2UI()
    {
        //Debug.Log($"amount: {(GameManager.MAX_GAMETIME - GameManager.GetInstance().Timer) / GameManager.MAX_GAMETIME}");
        _o2Bar.fillAmount = (GameManager.MAX_GAMETIME - GameManager.GetInstance().Timer) / GameManager.MAX_GAMETIME;
    }
}
