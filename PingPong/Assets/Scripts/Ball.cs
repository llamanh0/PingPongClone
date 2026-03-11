using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speedMultiplier = 1.1f;
    [SerializeField] private float maxSpeed = 20f;

    private float _currentSpeed;

    [Header("Referances")]
    [SerializeField] private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        _currentSpeed = initialSpeed;
        LaunchBall();
    }

    /// <returns>
    /// True or False
    /// </returns>
    private bool RandomBool()
    {
        return Random.value > 0.5f;
    }

    /// <summary>
    /// Topun yonune gore hareket ettirir.
    /// </summary>
    private void LaunchBall()
    {
        float xDirection = RandomBool() ? 1f : -1f;
        float yDirection = RandomBool() ? 0.5f : 0.5f;

        _rb.linearVelocity = new Vector2(xDirection, yDirection) * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IncreaseSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        if(_currentSpeed > maxSpeed)
        {
            _currentSpeed = maxSpeed;
        }else
        {
            _currentSpeed *= speedMultiplier;
            _rb.linearVelocity = _rb.linearVelocity.normalized * _currentSpeed;
        }
    }
}
