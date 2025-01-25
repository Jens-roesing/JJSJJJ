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
    
    [SerializeField]    private int BubbleRows = 0;
    [SerializeField]    private int BubbleColumns = 0;
    [SerializeField] private float distanceMod = 1.0f;


    public Bubble[,] Bubbles;

    private List<Bubble> ActiveBubbles = new();

    public static BubbleManager Instance { get; private set; }
    public float DistanceMod { get => distanceMod;}
    public int Columns => BubbleColumns;

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
        Analyzer.CalculateResults(ActiveBubbles.Count);
        for (int i = 0; i < ActiveBubbles.Count; i++)
            ActiveBubbles[i].PopCheck();
        ActiveBubbles.Clear();

    }
    public void RoundEndActions()
    {
        Raiser.RaiseBubbles();
        // Spawner.FillUpBubbles(ViewCam);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
