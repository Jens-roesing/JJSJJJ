using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField]
    private float DistanceMod = 20.0f;
    [SerializeField]
    Bubble BubblePrefab;
    [SerializeField]
    BubbleManager bubbleManager;
    public void FillUpBubbles()
    {
        for (int j = 0; j < bubbleManager.Bubbles.GetLength(1); j++)
            for (int i = 0; i < bubbleManager.Bubbles.GetLength(0); i++)
            {
                if (bubbleManager.Bubbles[i, j] == null)
                {
                    Bubble b = Instantiate(BubblePrefab);
                    bubbleManager.Bubbles[i, j] = b;
                    b.Init(bubbleManager, new Vector2Int(i, j));
                    b.transform.position= new Vector3(i*DistanceMod, j*DistanceMod, 0);    

                }

            }

    }
}
