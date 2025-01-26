using UnityEngine;

public class creditController : MonoBehaviour
{
    [SerializeField]
    Animator CreditsRollAnim;
    public void ToggleOn()
    {
        transform.gameObject.SetActive(true);
        CreditsRollAnim.SetBool("Playing", true);
    }

    public void ToggleOff()
    {
        transform.gameObject.SetActive(false);
        CreditsRollAnim.SetBool("Playing", false);
    }
}
