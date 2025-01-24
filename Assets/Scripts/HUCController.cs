using System;
using TMPro;
using UnityEngine;

public class HUCController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;

    void Start()
    {
        
    }

    void Update()
    {
        var ts = TimeSpan.FromSeconds(GameManager.GetInstance().Timer);
        _timer.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
    }
}
