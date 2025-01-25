using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUCController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private Image _o2Bar;

    private void Start()
    {
        
    }

    private void Update()
    {
        var ts = TimeSpan.FromSeconds(GameManager.GetInstance().Timer);
        _timer.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);

        UpdateO2UI();
    }

    private void UpdateO2UI()
    {
        //Debug.Log($"amount: {(GameManager.MAX_GAMETIME - GameManager.GetInstance().Timer) / GameManager.MAX_GAMETIME}");
        _o2Bar.fillAmount = (GameManager.MAX_GAMETIME - GameManager.GetInstance().Timer) / GameManager.MAX_GAMETIME;
    }
}
