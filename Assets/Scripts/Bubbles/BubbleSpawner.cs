using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform holder;
    [SerializeField]
    Bubble BubblePrefab;
    public void FillUpBubbles(Camera viewCam)
    {
        for (int j = 0; j < BubbleManager.Instance.Bubbles.GetLength(1); j++)
            for (int i = 0; i < BubbleManager.Instance.Bubbles.GetLength(0); i++)
            {
                if (BubbleManager.Instance.Bubbles[i, j] == null)
                {
                    Bubble b = Instantiate(BubblePrefab, holder);
                    BubbleManager.Instance.Bubbles[i, j] = b;
                    b.Init(new Vector2Int(i, j), viewCam);
                    b.transform.localRotation = transform.rotation;
                    b.transform.localPosition = new Vector3(i * BubbleManager.Instance.DistanceMod, j * BubbleManager.Instance.DistanceMod, 0);

                }

            }

    }
}
