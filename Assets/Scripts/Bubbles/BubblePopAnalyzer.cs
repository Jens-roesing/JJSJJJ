using Unity.Mathematics;
using UnityEngine;

public class BubblePopAnalyzer : MonoBehaviour
{



    public void CalculateResults(int p_bubblesPopped, int p_bloodyBubbles)
    {
        int damage = p_bubblesPopped;
        damage += p_bloodyBubbles * 10;
     
     
     
     
     
        if (EnemyHealth.GetInstance())     
            if (EnemyHealth.GetInstance().RemoveLifepoints(damage))
            {
                Debug.Log("You Won, guy.");
            }

    }
}
