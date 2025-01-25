using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUCController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private Image _o2Bar;

    void Start()
    {
        
    }

    void Update()
    {
        var ts = TimeSpan.FromSeconds(GameManager.GetInstance().Timer);
        _timer.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
    }
}
