using UnityEngine;

public class BubbleRaiser : MonoBehaviour
{

            bool FullyDone = true;

    public void RaiseBubbles()
    {
        do
        {
            FullyDone = true;

            for (int j = 0; j < BubbleManager.Instance.Bubbles.GetLength(1); j++)
                for (int i = 1; i < BubbleManager.Instance.Bubbles.GetLength(0); i++)
                {
                    if (BubbleManager.Instance.Bubbles[i, j] == null)
                        continue;
                    if (!BubbleManager.Instance.Bubbles[i, j].AboveCheck())
                        continue;
                    FullyDone = false;
                    Bubble curBub = BubbleManager.Instance.Bubbles[i, j];
                    BubbleManager.Instance.Bubbles[i, j + 1] = curBub;
                    BubbleManager.Instance.Bubbles[i, j] = null;
                    curBub.BubblePos.y++;
                    //Replace with Animation Movement
                    curBub.transform.localPosition = new Vector3(curBub.transform.localPosition.x, curBub.transform.position.y + BubbleManager.Instance.DistanceMod, curBub.transform.localPosition.z);
                }
        } while (!FullyDone);
    }






}
