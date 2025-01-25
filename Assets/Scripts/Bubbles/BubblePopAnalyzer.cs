using UnityEngine;

public class BubblePopAnalyzer : MonoBehaviour
{



    public void CalculateResults(int p_bubblesPopped)
    {
        int damage = p_bubblesPopped;


        if(EnemyHealth.GetInstance().RemoveLifepoints(damage))
        {
            Debug.Log("You Won, guy.");
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
