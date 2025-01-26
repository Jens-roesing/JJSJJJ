using UnityEngine;

public class KrakenManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator tentacle;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.GetInstance();
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
    }
}
