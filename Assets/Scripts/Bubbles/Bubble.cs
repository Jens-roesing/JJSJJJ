using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public enum BubbleColour
{
    Blue,
    Yellow,
    Red,
}

public enum BubbleMods
{
    None,
    Bloody,
    TimeBubble,
    Paralyzing,
    Inked,

}
public class Bubble : MonoBehaviour
{
    private const int MODRARITY = 10;
    private const float POP_ANIM_SPEED = 0.05f;
    [SerializeField]
    SpriteRenderer mySprite;
    [SerializeField]
    Camera ViewCam;
    private bool isChosen;
    [SerializeField] private Sprite[] _popSprites;
    public BubbleColour bubbleColour;
    public Vector2Int BubblePos;
    public SpriteRenderer Sprite => mySprite;
    public BubbleMods BubbleModifier;
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
        uint ModId = (uint)UnityEngine.Random.Range(0, Enum.GetValues(typeof(BubbleMods)).Length + MODRARITY);
        BubbleModifier = (BubbleMods)ModId - (MODRARITY + 1);
        if (BubbleModifier != BubbleMods.None)
        {
            SpriteRenderer plaque = Instantiate(new GameObject()).AddComponent<SpriteRenderer>();
            plaque.transform.SetParent(transform.GetChild(0).GetChild(0));
            switch (BubbleModifier)
            {
                case BubbleMods.Bloody:
                
                break;
                case BubbleMods.TimeBubble:
                break;
                case BubbleMods.Paralyzing:
                break;

            }

        }



    }
    public void ActivationHandler(bool _mode)
    {
        isChosen = _mode;

        Debug.Log("Added Bubble: " + BubblePos);
        mySprite.color = Color.cyan;
        AudioManager.GetInstance().PlaySelectSound(BubbleManager.Instance.SelectedBubbles);
        //TODO: Change Colour if selected 
    }
    public void Inkify()
    {
        BubbleModifier = BubbleMods.Inked;
        mySprite.color = Color.black;
    }
    public bool WasHit()
    {
        if (isChosen)
            return false;
        if (BubbleManager.Instance.BubbleUpdateRequest(this))
        {
            ActivationHandler(true);
            return true;
        }

        return false;
    }
    /// <summary>
    /// Information for the BubbleRaiser to know if he needs to raise this bubble
    /// </summary>
    /// <returns></returns>
    public bool CheckAboveForEmpty()
    {
        bool raise = false;
        raise = BubbleManager.Instance.Bubbles[BubblePos.x, Mathf.Clamp(BubblePos.y + 1, 0, BubbleManager.Instance.Columns - 1)] == null;

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
            StartCoroutine(Pop());

    }

    public IEnumerator Pop()
    {
        for (int i = 0; i < _popSprites.Length; i++)
        {
            yield return new WaitForSeconds(POP_ANIM_SPEED);
            mySprite.sprite = _popSprites[i];
        }

        BubbleManager.Instance.Bubbles[BubblePos.x, BubblePos.y] = null;
        Destroy(gameObject);
        yield return null;
    }

    private void Update()
    {

        transform.LookAt(ViewCam.transform.position, Vector3.up);
    }
}
