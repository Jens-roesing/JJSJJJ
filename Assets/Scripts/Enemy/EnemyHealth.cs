using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private const int MAX_LIFEPOINTS = 100;
    [SerializeField] private GameObject _healthBarParent;
    [SerializeField] private Image _healthBar;
    public int lifePoints { get; private set; }


    private void Start()
    {
        InitUI();
        GameManager.GetInstance().NewGameState.AddListener(Show);
    }

    private void Show(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Playing)
            _healthBarParent.SetActive(true);

        if (state == GameManager.GameState.Pause)
            _healthBarParent.SetActive(false);
    }

    private void InitUI()
    {
        _healthBarParent.SetActive(false);
        _healthBar.fillAmount = 1;
    }

    public void RemoveLifepoints(int amout)
    {
        lifePoints -= amout;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _healthBar.fillAmount = Mathf.Lerp(0, 1, lifePoints / 100);
    }
}
