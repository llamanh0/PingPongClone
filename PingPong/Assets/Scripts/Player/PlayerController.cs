using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float moveSpeed;

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rb == null) { return; }

        HandleMovement();
    }

    private void HandleMovement()
    {
        if (player == Player.One)
        {
            _rb.linearVelocityY = ((Keyboard.current.wKey.isPressed ? 1 : 0) + (Keyboard.current.sKey.isPressed ? -1 : 0)) * moveSpeed;
        }
        if (player == Player.Two)
        {
            _rb.linearVelocityY = ((Keyboard.current.upArrowKey.isPressed ? 1 : 0) + (Keyboard.current.downArrowKey.isPressed ? -1 : 0)) * moveSpeed;
        }
    }
}
