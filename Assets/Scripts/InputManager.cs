using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Camera cammy;

    Mouse mouse;
    bool HasBeenPressed = false;

    [SerializeField]
    BubbleManager bub;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mouse.leftButton.isPressed)
        {
            HasBeenPressed = true;
            Vector3 mousePos = mouse.position.ReadValue();
            Ray mousePoint = cammy.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mousePoint, out RaycastHit HitBubble))
            {
                if (HitBubble.transform.gameObject.TryGetComponent<Bubble>(out Bubble hitBubble))
                    hitBubble.WasHit();
            }
        }
        if (HasBeenPressed && !mouse.leftButton.isPressed)
        {
            bub.TempCheck();
            HasBeenPressed = false;
        }

    }
}
