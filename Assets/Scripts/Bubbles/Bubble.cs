using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer mySprite;
    [SerializeField]
    Camera ViewCam;
    private bool isChosen;
    public Vector2Int BubblePos;
    public SpriteRenderer Sprite => mySprite;
    public void Init(Vector2Int _initPos, Camera p_vCam)
    {
        BubblePos = _initPos;

        ViewCam = p_vCam;


    }
    public void ActivationHandler(bool _mode)
    {
        isChosen = _mode;

        Debug.Log("Added Bubble: " + BubblePos);
        mySprite.color = Color.cyan;
        //TODO: Change Colour if selected 
    }

    public void WasHit()
    {
        if (isChosen)
            return;
        if (BubbleManager.Instance.BubbleUpdateRequest(BubblePos))
            ActivationHandler(true);
    }
    /// <summary>
    /// Information for the BubbleRaiser to know if he needs to raise this bubble
    /// </summary>
    /// <returns></returns>
    public bool CheckAboveForEmpty()
    {
        bool raise = false;
        raise =  BubbleManager.Instance.Bubbles[BubblePos.x, Mathf.Clamp(BubblePos.y + 1, 0, BubbleManager.Instance.Columns)] == null;

        Debug.Log($"Needs Raise ({raise}): X{BubblePos.x} Y{BubblePos.y}");

        return raise;
    }
    /// <summary>
    /// checks if the bubble needs to be popped and does so if yes.
    /// </summary>
    /// 
    public void PopCheck()
    {
        if (isChosen)
            //TODO: Play Animation and have that triggers the Pop command.
            Pop();

    }
    public void Pop()
    {
        BubbleManager.Instance.Bubbles[BubblePos.x, BubblePos.y] = null;
        Destroy(gameObject);
    }

    private void Update()
    {

        transform.LookAt(ViewCam.transform.position, Vector3.up);
    }
}
