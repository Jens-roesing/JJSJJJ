using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private const int MAX_LIFEPOINTS = 100;
    private static EnemyHealth instance;
    [SerializeField] private TextMeshProUGUI _lifeCounter;
    [SerializeField] private GameObject _healthBarParent;
    [SerializeField] private Image _healthBar;
    [SerializeField] private bool debugMode = true;
    public int lifePoints { get; private set; } = 100;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        InitUI();
        GameManager.GetInstance().NewGameState.AddListener(Show);
    }

    private void Update()
    {
        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                AddLifepoints(10);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                RemoveLifepoints(10);
        }
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

    /// <summary>
    /// Removes Lifepoints, returns true when enemy has 0 lifepoints left.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool RemoveLifepoints(int amount)
    {
        Mathf.Clamp(lifePoints -= amount, 0, MAX_LIFEPOINTS);
        UpdateUI();
        AudioManager.GetInstance().PlayKrakenDMGSound();

        return lifePoints <= 0;
    }

    public void AddLifepoints(int amount)
    {
        Mathf.Clamp(lifePoints += amount, 0, MAX_LIFEPOINTS);
        UpdateUI();
    }

    private void UpdateUI()
    {
        _lifeCounter.text = $"{lifePoints} Lifes";
        _healthBar.fillAmount = (float)lifePoints / 100;
    }

    public static EnemyHealth GetInstance()
    {
        return instance;
    }
}
