using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -0.3f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 0.3f;
        }
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 0.3f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -0.3f;
        }

        Vector2 position = transform.position;
        position.x += horizontal * 0.1f;
        position.y += vertical * 0.1f;
        transform.position = position;
    }
}
