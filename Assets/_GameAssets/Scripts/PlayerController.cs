using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables related to player character movement
    private Rigidbody2D _rb;
    private Vector2 _move;
    public InputAction MoveAction;
    public float speed = 3.0f;


    // Variables related to the health system
    public int MaxHealth { get { return maxHealth; } }
    [SerializeField] private int maxHealth = 5;

    public int Health { get { return currentHealth; } }
    private int currentHealth = 1;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
        currentHealth = maxHealth;
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

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
