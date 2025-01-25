using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    private BubbleSpawner Spawner;
    [SerializeField]
    private BubbleRaiser Raiser;
    [SerializeField]
    private int BubbleRows = 0;
    [SerializeField]
    private int BubbleColumns = 0;
    public Bubble[,] Bubbles;

    private List<Bubble> ActiveBubbles = new List<Bubble>();





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        Bubbles = new Bubble[BubbleRows, BubbleColumns];
        Spawner.FillUpBubbles();

    }

    public bool BubbleUpdateRequest(Vector2Int bubblePos)
    {
        Debug.Log("Bubble " + bubblePos + " Requests a check");
        //Check if Bubble is either first or neighbour to the previous hit one.
        if (ActiveBubbles.Count != 0)
        {
            Debug.Log("Works til here count before: " + ActiveBubbles.Count);
            Vector2Int oldPos = ActiveBubbles.Last().BubblePos;
            if (Vector2.Distance(oldPos, bubblePos) <= 1.5f)
            {

                ActiveBubbles.Add(Bubbles[bubblePos.x, bubblePos.y]);
                Debug.Log("Works til here count after: " + ActiveBubbles.Count);

                return true;
            }

            return false;
        }
        ActiveBubbles.Add(Bubbles[bubblePos.x, bubblePos.y]);
        Debug.Log("First bubble: " + bubblePos);
        return true;
    }

    public void TempCheck()
    {
        for (int i = 0; i < ActiveBubbles.Count; i++)
        {
            ActiveBubbles[i].PopCheck();
        }
        ActiveBubbles.Clear();
    }
    public void RoundEndActions()
    {
        Raiser.RaiseBubbles();
        Spawner.FillUpBubbles();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
