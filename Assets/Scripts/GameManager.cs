using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static float MAX_GAMETIME { get; private set; } = 30; //seconds
    public GameState State { get; private set; }
    public UnityEvent<GameState> NewGameState = new UnityEvent<GameState>();
    public float Timer { get; private set; }

    public enum GameState
    {
        None = 0,
        Menu = 1,
        Playing = 2,
        Lose = 3,
        Win = 4,
        Pause = 5,
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

        if (State == GameState.Playing)
        {
            Timer += Time.deltaTime;

            if (Timer > MAX_GAMETIME && EnemyHealth.GetInstance().lifePoints > 0)
                SetGameState(GameState.Lose);

            if (Timer < MAX_GAMETIME && EnemyHealth.GetInstance().lifePoints <= 0)
                SetGameState(GameState.Win);
        }
    }

    public void AddAir(float addedTime)
    {
        Mathf.Clamp(Timer -= addedTime, 0, float.MaxValue);

    }
    public void SetGameState(GameState newGameState)
    {
        State = newGameState;
        NewGameState.Invoke(newGameState);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}
