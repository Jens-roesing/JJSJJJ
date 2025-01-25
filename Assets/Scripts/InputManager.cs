using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Camera cammy;

    [SerializeField]
    LineRenderer lineRenderer;
    Mouse mouse;
    bool HasBeenPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
    }
    int manCounter = 0;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance())
            if (GameManager.GetInstance().State != GameManager.GameState.Playing)
                return;

        if (mouse.leftButton.isPressed)
        {
            HasBeenPressed = true;
            Vector3 mousePos = mouse.position.ReadValue();
            Ray mousePoint = cammy.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mousePoint, out RaycastHit HitBubble))
            {
                if (HitBubble.transform.gameObject.TryGetComponent<Bubble>(out Bubble hitBubble))
                    if (hitBubble.WasHit())
                    {
                        Debug.Log("Boop");
                        lineRenderer.positionCount++;
                        Vector3 LRPos = hitBubble.transform.position;
                        LRPos.z += 1f;
                        lineRenderer.SetPosition(manCounter, LRPos);
                        manCounter++;
                    }
            }
        }
        if (HasBeenPressed && !mouse.leftButton.isPressed)
        {
            lineRenderer.positionCount = 0;
            BubbleManager.Instance.ResultCheck();
            HasBeenPressed = false;
            manCounter = 0;
        }

    }
}
