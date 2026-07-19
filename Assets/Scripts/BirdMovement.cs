using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 15f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool mousePressed = Mouse.current.leftButton.wasPressedThisFrame;
        bool spacePressed = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (mousePressed || spacePressed)
        {
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rotationSpeed * _rb.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GamerOver();
    }
}