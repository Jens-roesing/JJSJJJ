using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleRaiser : MonoBehaviour
{
    int count = 0;
    bool FullyDone = true;
    private Dictionary<Bubble, Vector3> BubblesAnimations = new Dictionary<Bubble, Vector3>();
    [SerializeField] private float animSpeed = 10;

    [ContextMenu("RaiseBubbles")]
    public void RaiseBubbles()
    {
        BubblesAnimations = new Dictionary<Bubble, Vector3>();
        do
        {
            FullyDone = true;
            count++;
            Debug.LogWarning("" + count + "/" + BubbleManager.Instance.Columns * 2);
            if (count >= BubbleManager.Instance.Columns * 2)
            {

                count = 0;
                return;
            }

            for (int j = 0; j < BubbleManager.Instance.Bubbles.GetLength(1); j++)
                for (int i = 0; i < BubbleManager.Instance.Bubbles.GetLength(0); i++)
                {
                    if (BubbleManager.Instance.Bubbles[i, j] == null)
                        continue;
                    if (!BubbleManager.Instance.Bubbles[i, j].CheckAboveForEmpty())
                        continue;
                    FullyDone = false;
                    Bubble curBub = BubbleManager.Instance.Bubbles[i, j];

                    BubbleManager.Instance.Bubbles[i, j + 1] = curBub;
                    BubbleManager.Instance.Bubbles[i, j] = null;
                    curBub.BubblePos.y++;

                    Vector3 targetPosition = new Vector3(curBub.transform.localPosition.x, curBub.transform.localPosition.y + BubbleManager.Instance.DistanceMod, curBub.transform.localPosition.z);
                    if (BubblesAnimations.ContainsKey(curBub))
                    {
                        // Support for bubbles that get destroyed for lines from top to down
                        Transform tempBubblePos = curBub.transform;
                        tempBubblePos.localPosition = BubblesAnimations[curBub];
                        Vector3 secondTargetPosition = new Vector3(tempBubblePos.transform.localPosition.x, tempBubblePos.transform.localPosition.y + BubbleManager.Instance.DistanceMod, tempBubblePos.transform.localPosition.z);
                        BubblesAnimations[curBub] = secondTargetPosition;
                    }
                    else
                        BubblesAnimations.Add(curBub, targetPosition);

                    //Replace with Animation Movement
                    //curBub.transform.localPosition = new Vector3(curBub.transform.localPosition.x, curBub.transform.localPosition.y + BubbleManager.Instance.DistanceMod, curBub.transform.localPosition.z);
                }
        } while (!FullyDone);

        foreach (Bubble bubble in BubblesAnimations.Keys)
        {
            if (bubble != null)
                StartCoroutine(MoveBubble(bubble, BubblesAnimations[bubble]));
        }

        count = 0;
    }

    private IEnumerator MoveBubble(Bubble curbBubble, Vector3 targetPosition)
    {
        Vector3 startPosition = curbBubble.transform.localPosition;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * animSpeed;
            curbBubble.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, timer);
            yield return null;
        }
        yield return null;
    }
}
