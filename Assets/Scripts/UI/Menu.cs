using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private static Menu instance;
    [SerializeField] private TextMeshProUGUI _headline;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _container;
    [SerializeField] private BubbleManager _bubbleManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;

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
        GameManager.GetInstance().SetGameState(GameManager.GameState.Playing);
        _bubbleManager.StartGame();

        _container.SetActive(false);
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
        _container.SetActive(true);
        _startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Resume Game";
    }

    public static Menu GetInstance()
    {
        return instance;
    }
}
