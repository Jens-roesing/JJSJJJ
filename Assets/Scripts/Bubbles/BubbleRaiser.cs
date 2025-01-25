using UnityEngine;

public class BubbleRaiser : MonoBehaviour
{

    public void RaiseBubbles()
    {
        for (int j = 0; j < BubbleManager.Instance.Bubbles.GetLength(1); j++)
            for (int i = 1; i < BubbleManager.Instance.Bubbles.GetLength(0); i++)
            {
                if (BubbleManager.Instance.Bubbles[i, j] == null && !BubbleManager.Instance.Bubbles[i, j].AboveCheck())
                    continue;
                Bubble curBub = BubbleManager.Instance.Bubbles[i, j];
                do
                {
                    BubbleManager.Instance.Bubbles[i, j + 1] = curBub;
                    BubbleManager.Instance.Bubbles[i, j] = null;
                    curBub.BubblePos.y++;
                    //Replace with Animation Movement
                    curBub.transform.position = new Vector3(curBub.transform.position.x, curBub.transform.position.y + 20, curBub.transform.position.z);

                } while (curBub.AboveCheck());
            }
    }






}
