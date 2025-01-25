using UnityEngine;

public class hackstart : MonoBehaviour
{
    public BubbleManager bubbleManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       bubbleManager.StartGame(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
