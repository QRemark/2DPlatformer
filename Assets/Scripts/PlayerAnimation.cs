using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _localScale = 5;

    private float _animatorSpeedScaler = 2.0f;

    private string _animatorSpeed = "Speed";
    private string _animatorJump = "IsJump";

    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void PlayJump(UserInput userInput)
    {
        if (userInput.VerticalInput)
        {
            _animator.SetBool(_animatorJump, true);
            _animator.SetFloat(_animatorSpeed, 0);
        }
        else if (_animator.GetBool(_animatorJump) && _playerRigidbody.velocity.y <= 0.0f)
        {
            _animator.SetBool(_animatorJump, false);
        }
    }

    public void PlayIdle(UserInput userInput)
    {
        if (IsJumping() == false && userInput.HorizontalInput == 0.0f)
        {
            FlipSprite(userInput);
            _animator.SetFloat(_animatorSpeed, Mathf.Abs(0));
        }
    }

    public void PlayWalk(UserInput userInput)
    {
        if (IsJumping() == false && userInput.HorizontalInput != 0.0f && userInput.ShiftInput == false)
        {
            FlipSprite(userInput);
            _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput));
        }
    }

    public void PlayRun(UserInput userInput)
    {
        if (IsJumping() == false && userInput.HorizontalInput != 0.0f && userInput.ShiftInput == true)
        {
            FlipSprite(userInput);
            _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput) * _animatorSpeedScaler);
        }
    }

    private bool IsJumping() => _animator.GetBool(_animatorJump);

    private void FlipSprite(UserInput userInput)
    {
        if (userInput.HorizontalInput < 0.0f)
            transform.localScale = new Vector3(-_localScale, _localScale, 1);
        else if (userInput.HorizontalInput > 0.0f)
            transform.localScale = new Vector3(_localScale, _localScale, 1);
    }
}
