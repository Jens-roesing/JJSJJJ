
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Animation _loseAnimation;
    [SerializeField] private Animator _chestAnimation;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private TextMeshProUGUI winText;

    private void Start()
    {
        GameManager.GetInstance().NewGameState.AddListener(HandleGameState);
    }

    private void HandleGameState(GameManager.GameState State)
    {
        if (State == GameManager.GameState.Lose)
            ShowLoseScreen();

        if (State == GameManager.GameState.Win)
            ShowWinScreen();
    }

    private void ShowLoseScreen()
    {
        _loseAnimation.Play();
        loseText.gameObject.SetActive(true);
        StartCoroutine(RestartGame(5f));
    }

    private void ShowWinScreen()
    {
        Debug.Log("Show Lose Screen");
        _chestAnimation.SetTrigger("Open");
        winText.gameObject.SetActive(true);
        StartCoroutine(RestartGame(5f));
    }

    private IEnumerator RestartGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
