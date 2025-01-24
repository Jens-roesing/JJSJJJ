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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bubbles = new Bubble[BubbleRows, BubbleColumns];
        Spawner.FillUpBubbles();

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
