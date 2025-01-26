using System.Collections;
using UnityEngine;

public class KrakenManager : MonoBehaviour
{
    [SerializeField] private Animator _tentacleUpDownAni;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator tentacle;
    [SerializeField] private float inkDelay = 2f;
    private AudioManager audioManager;
    private float nextAttackDelay = 0;
    private float timer = 0;

    void Start()
    {
        audioManager = AudioManager.GetInstance();
        GameManager.GetInstance().NewGameState.AddListener(HandleGameState);
        nextAttackDelay = UnityEngine.Random.Range(6, 10);
    }

    private void Update()
    {
        if (GameManager.GetInstance().State == GameManager.GameState.Playing)
        {
            timer += Time.deltaTime;

            if (timer >= nextAttackDelay)
            {
                timer = 0;
                nextAttackDelay = UnityEngine.Random.Range(6, 10);
                Debug.Log($"next Attack in {nextAttackDelay} sec.");
                StartCoroutine(PlayAttack());
            }
        }
    }

    private IEnumerator PlayAttack()
    {
        tentacle.SetTrigger("Attack");
        yield return new WaitForSeconds(inkDelay);
        BubbleManager.Instance.InkSplatter(UnityEngine.Random.Range(2, 5));
    }

    private void HandleGameState(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Win)
            PlayDeathAnimation();
    }

    [ContextMenu("PlayDmgAnimation")]
    private void PlayDmgAnimation()
    {
        animator.SetTrigger("Damage");
        audioManager.PlayKrakenDMGSound();
    }

    [ContextMenu("PlayDeathAnimation")]
    private void PlayDeathAnimation()
    {
        animator.SetBool("Death", true);
        _tentacleUpDownAni.SetTrigger("Down");
        audioManager.PlayKrakenDeathSound();
    }
}
