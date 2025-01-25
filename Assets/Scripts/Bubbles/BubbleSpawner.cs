using UnityEngine;
public class BubbleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform holder;
    [SerializeField]
    Bubble BubblePrefab;
    public void FillUpBubbles(Camera viewCam)
    {
        for (int y = 0; y < BubbleManager.Instance.Bubbles.GetLength(1); y++)
            for (int x = 0; x < BubbleManager.Instance.Bubbles.GetLength(0); x++)
            {
                if (BubbleManager.Instance.Bubbles[x, y] == null)
                {
                    Bubble b = Instantiate(BubblePrefab, holder);
                    BubbleManager.Instance.Bubbles[x, y] = b;
                    b.Init(new Vector2Int(x, y), viewCam);
                    b.transform.localRotation = transform.rotation;
                    b.transform.localPosition = new Vector3(x * BubbleManager.Instance.DistanceMod, y * BubbleManager.Instance.DistanceMod, 0);

                }

            }

    }
}
