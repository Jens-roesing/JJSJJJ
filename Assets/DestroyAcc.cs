using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class DestroyAcc : MonoBehaviour
{
    public void Destrudo()
    {
        transform.parent.transform.parent.GetComponent<Bubble>().Pop();
    }
}