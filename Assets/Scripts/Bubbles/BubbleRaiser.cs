using Unity.VisualScripting;
using UnityEngine;

public class BubbleRaiser : MonoBehaviour
{
    int count = 0;
    bool FullyDone = true;
    [ContextMenu("RaiseBubbles")]
    public void RaiseBubbles()
    {
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
                    //Replace with Animation Movement
                    curBub.transform.localPosition = new Vector3(curBub.transform.localPosition.x, curBub.transform.localPosition.y + BubbleManager.Instance.DistanceMod, curBub.transform.localPosition.z);
                }
        } while (!FullyDone);

        count = 0;
    }






}
