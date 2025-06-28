using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;

    void Start()
    {
        MoveAction.Enable();
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * (3.0f * Time.deltaTime);
        transform.position = position;
    }
}
