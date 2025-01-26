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

    private void PlayDmgAnimation()
    {
        animator.SetTrigger("Damage");
        audioManager.PlayKrakenDMGSound();
    }

    private void PlayDeathAnimation()
    {
        animator.SetBool("Death", true);
    }
}
