using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(UserInput))]
//[RequireComponent(typeof(UserInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private float _speedScaller = 2f;

    private Rigidbody2D _playerRigidbody;
    
    private float _horizontalInput;

    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChangePositionX(UserInput userInput)
    {
        Vector2 velocity = _playerRigidbody.velocity;

        velocity.x = userInput.HorizontalInput * _moveSpeed;

        _playerRigidbody.velocity = velocity;
    }

    public void ChangePositionXSpeed(UserInput userInput)
    {
        Vector2 velocity = _playerRigidbody.velocity;

        velocity.x = userInput.HorizontalInput * _moveSpeed * _speedScaller;

        _playerRigidbody.velocity = velocity;
    }

    public void ChangePositionY(UserInput userInput, bool isGround)
    {
        if (userInput.VerticalInput && isGround)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void FlipSprite(UserInput userInput)
    {
        if (userInput.HorizontalInput < 0.0f)
            transform.localRotation = _rotateLeft;
        else if (userInput.HorizontalInput > 0.0f)
            transform.localRotation = _rotateRight;
    }
}
