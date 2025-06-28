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
    public int MaxHealth { get { return _maxHealth; } }
    [SerializeField] private int _maxHealth = 5;

    public int Health { get { return _currentHealth; } }
    private int _currentHealth = 1;

    [SerializeField] private float _timeInvincible = 2.0f;

    private bool _isInvincible;

    private float _damageCooldown;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();

        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _move = MoveAction.ReadValue<Vector2>();

        if (_isInvincible)
        {
            _damageCooldown -= Time.deltaTime;
            if (_damageCooldown < 0)
            {
                _isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = _rb.position + _move * (3.0f * Time.deltaTime);
        _rb.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (_isInvincible)
            {
                return;
            }
            _isInvincible = true;
            _damageCooldown = _timeInvincible;
        }

        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        UIHandler.instance.SetHealthValue(_currentHealth / (float)_maxHealth);

    }
}
