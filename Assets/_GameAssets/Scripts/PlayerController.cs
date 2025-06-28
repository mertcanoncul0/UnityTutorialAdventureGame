using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private Rigidbody2D _rb;
    private Vector2 _move;

    void Start()
    {
        MoveAction.Enable();
        _rb = GetComponent<Rigidbody2D>();
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        _move = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 position = _rb.position + _move * (3.0f * Time.deltaTime);
        _rb.MovePosition(position);
    }
}
