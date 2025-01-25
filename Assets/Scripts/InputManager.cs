using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Camera cammy;

    Mouse mouse;
    bool HasBeenPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().State != GameManager.GameState.Playing)
        return;

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
            BubbleManager.Instance.TempCheck();
            HasBeenPressed = false;
        }

    }
}
