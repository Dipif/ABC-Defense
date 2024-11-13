using UnityEngine;

public class InputEventManager : MonoBehaviour
{
    private void Update()
    {
        Vector2 downPosition = Vector2.zero;
        Vector2 upPosition = Vector2.zero;
        // touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                downPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch Moved");
            }
            if (touch.phase == TouchPhase.Ended)
            {
                upPosition = touch.position;
            }
        }


        // mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            downPosition = Input.mousePosition;
        }
        // mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            upPosition = Input.mousePosition;
        }

    }
}