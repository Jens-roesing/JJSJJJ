using UnityEngine;

public class creditController : MonoBehaviour
{
    [SerializeField]
    Animation CreditsRollAnim;
    public void ToggleOn()
    {
        transform.gameObject.SetActive(true);
        CreditsRollAnim.Play();
    }

    public void ToggleOff()
    {
        transform.gameObject.SetActive(false);
    }
}
