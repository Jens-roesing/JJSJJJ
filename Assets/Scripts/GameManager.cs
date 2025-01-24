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

        SetGameState(GameState.Menu);
    }

    private void Start()
    {
        
    }

    private void SetGameState(GameState newGameState)
    {
        NewGameState.Invoke(newGameState);
    }

    public GameManager GetInstance()
    {
        return instance;
    }
}
