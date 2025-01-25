using System;
using Unity.VisualScripting;
using UnityEngine;
public enum BubbleColour
{
    Blue,
    Yellow,
    Red,
}
public class Bubble : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer mySprite;
    [SerializeField]
    Camera ViewCam;
    private bool isChosen;
    public BubbleColour bubbleColour;
    public Vector2Int BubblePos;
    public void Init(Vector2Int _initPos, Camera p_vCam)
    {
        BubblePos = _initPos;

        ViewCam = p_vCam;
        int colorID = UnityEngine.Random.Range(0, Enum.GetValues(typeof(BubbleColour)).Length);
        bubbleColour = (BubbleColour)colorID;
        switch (bubbleColour)
        {
            case BubbleColour.Blue:
                mySprite.color = Color.blue;
                break;
            case BubbleColour.Yellow:
                mySprite.color = Color.yellow;
                break;
            case BubbleColour.Red:
                mySprite.color = Color.red;
                break;
        }

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
        if (BubbleManager.Instance.BubbleUpdateRequest(BubblePos, bubbleColour))
            ActivationHandler(true);
    }
    /// <summary>
    /// Information for the BubbleRaiser to know if he needs to raise this bubble
    /// </summary>
    /// <returns></returns>
    public bool CheckAboveForEmpty()
    {
        if (BubblePos.y >= BubbleManager.Instance.Bubbles.GetLength(1) - 1)
        {
            bool v = BubbleManager.Instance.Bubbles[BubblePos.x, BubblePos.y + 1] == null;
            return v;
        }

        return false;
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

        Destroy(gameObject);
    }

    private void Update()
    {

        transform.LookAt(ViewCam.transform.position, Vector3.up);
    }
}
