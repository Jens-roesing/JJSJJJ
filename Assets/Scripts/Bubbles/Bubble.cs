using UnityEngine;

public class Bubble : MonoBehaviour
{
    BubbleManager ParentManager;
    private bool isChosen;
    private Vector2Int BubblePos;
public void Init(BubbleManager _parentManager, Vector2Int _initPos)
{
    ParentManager = _parentManager;
    BubblePos = _initPos;


}
public void ActivationHandler(bool _mode)
{
    isChosen = _mode;
    //TODO: Change Colour if selected 
}
/// <summary>
/// Information for the BubbleRaiser to know if he needs to raise this bubble
/// </summary>
/// <returns></returns>
public bool AboveCheck()
{
    if(ParentManager.Bubbles[BubblePos.x, BubblePos.y+1] == null)
        return true;
    return false;
}
/// <summary>
/// checks if the bubble needs to be popped and does so if yes.
/// </summary>
public void PopCheck()
{
    if (isChosen)
    //TODO: Play Animation and have that trigger the 
        Destroy(gameObject);
}
}
