using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private const int MAX_LIFEPOINTS = 100;
    private static EnemyHealth instance;
    [SerializeField] private GameObject _healthBarParent;
    [SerializeField] private Image _healthBar;
    public int lifePoints { get; private set; }

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

        return lifePoints <= 0;
    }

    public void AddLifepoints(int amount)
    {
        Mathf.Clamp(lifePoints += amount, 0, MAX_LIFEPOINTS);
        UpdateUI();
    }

    private void UpdateUI()
    {
        _healthBar.fillAmount = Mathf.Lerp(0, 1, lifePoints / 100);
    }

    public EnemyHealth GetInstance()
    {
        return instance;
    }
}
