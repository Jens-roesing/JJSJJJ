using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameState State { get; private set; }
    public UnityEvent<GameState> NewGameState = new UnityEvent<GameState>();

    public enum GameState
    {
        None = 0,
        Menu = 1,
        GameStart = 2,
        Playing = 3,
        Lose = 4,
        Win = 5,
        Pause = 6,
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SetGameState(GameState.Menu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGameState(GameState.Pause);
        }
    }

    public void SetGameState(GameState newGameState)
    {
        NewGameState.Invoke(newGameState);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}
