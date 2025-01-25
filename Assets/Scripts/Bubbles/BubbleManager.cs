using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    Camera ViewCam;
    [SerializeField]
    private BubbleSpawner Spawner;
    [SerializeField]
    private BubbleRaiser Raiser;
    [SerializeField]
    BubblePopAnalyzer Analyzer;

    [SerializeField] private int BubbleRows = 0;
    [SerializeField] private int BubbleColumns = 0;
    [SerializeField] private float distanceMod = 1.0f;


    public Bubble[,] Bubbles;

    private List<Bubble> ActiveBubbles = new();

    public static BubbleManager Instance { get; private set; }
    public float DistanceMod { get => distanceMod; }
    public int Columns => BubbleColumns;

    private int BloodyBubbles = 0;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        Bubbles = new Bubble[BubbleRows, BubbleColumns];
        Spawner.FillUpBubbles(ViewCam);

    }

    public bool BubbleUpdateRequest(Bubble p_bubbleInQuestion)
    {
        // Debug.Log("Bubble " + bubblePos + " Requests a check");
        //Check if Bubble is either first or neighbour to the previous hit one.
        if (ActiveBubbles.Count != 0)
        {
            if (ActiveBubbles.Last().bubbleColour != p_bubbleInQuestion.bubbleColour)
                return false;
            if (p_bubbleInQuestion.BubbleModifier == BubbleMods.Inked)
                return false;
            Vector2Int oldPos = ActiveBubbles.Last().BubblePos;
            if (Vector2.Distance(oldPos, p_bubbleInQuestion.BubblePos) <= 1.5f)
            {
                ActiveBubbles.Add(Bubbles[p_bubbleInQuestion.BubblePos.x, p_bubbleInQuestion.BubblePos.y]);
                if(p_bubbleInQuestion.BubbleModifier == BubbleMods.Bloody)
                    BloodyBubbles++;

                return true;
            }
            return false;
        }

        ActiveBubbles.Add(Bubbles[p_bubbleInQuestion.BubblePos.x, p_bubbleInQuestion.BubblePos.y]);
        // Debug.Log("First bubble: " + bubblePos);
        return true;
    }

    public void ResultCheck()
    {

        Analyzer.CalculateResults(ActiveBubbles.Count, BloodyBubbles);
        BloodyBubbles = 0;
        for (int i = 0; i < ActiveBubbles.Count; i++)
            ActiveBubbles[i].PopCheck();

        StartCoroutine(Delay());


    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);

        ActiveBubbles.Clear();

        RoundEndActions();


    }
    public void RoundEndActions()
    {
        Raiser.RaiseBubbles();
        Spawner.FillUpBubbles(ViewCam);
    }
}
