using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UserInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpForce = 3.0f;
    [SerializeField] private float _speedScaller = 2f;

    private Rigidbody2D _playerRigidbody;

    private void FixedUpdate()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChangePositionX(UserInput userInput)
    {
        Vector2 velocity = _playerRigidbody.velocity;

        if (userInput.ShiftInput == true)
            velocity.x = userInput.HorizontalInput * _moveSpeed * _speedScaller;
        else
            velocity.x = userInput.HorizontalInput * _moveSpeed;

        _playerRigidbody.velocity = velocity;
    }

    public void ChangePositionY(UserInput userInput)
    {
        if (userInput.VerticalInput)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
