using UnityEngine;

[RequireComponent(typeof(UserInput), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation), typeof(GroundDetector), typeof(Collector))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GroundDetector _groundDetector;

    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

    private bool _isRunning;
    private bool _isJumping;

    private void Awake()
    {
        _userInput.OnJumpPressed += HandleJump;
        _userInput.OnMovePressed += HandleMove;
        _userInput.OnRunPressed += HandleRun;
    }

    private void Update()
    {
        _userInput.ListenKey();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        FlipSprite();
        UpdateMove();
    }

    private void UpdateMove()
    {
        if (_userInput.HorizontalInput != 0)
        {
            UpdateMoveX();
        }
        else
        {
            _playerMover.StopMoving();
        }
    }

    private void UpdateMoveX()
    {
        if (_isRunning)
            _playerMover.DirectXFast();
        else
            _playerMover.DirectX();
    }

    private void HandleJump()
    {
        if (_groundDetector.IsGround && _isJumping == false) 
        {
            _isJumping = true;
            _playerMover.DirectY();
            _playerAnimation.PlayJump();
        }
    }

    private void HandleMove(float direction)
    {
        _playerMover.SetDirection(direction);
    }

    private void HandleRun(bool isRunning)
    {
        _isRunning = isRunning;
    }

    private void UpdateAnimation()
    {
        if (_groundDetector.IsGround)
        {
            UpdateAnimationX();
        }
        else
        {
            if (_isJumping)
                return;

            _playerAnimation.PlayFall();
        }
    }

    private void UpdateAnimationX()
    {
        _isJumping = false;

        if (_userInput.HorizontalInput == 0)
        {
            _playerAnimation.PlayIdle();
        }
        else if (_isRunning)
        {
            _playerAnimation.PlayRun(_userInput);
        }
        else
        {
            _playerAnimation.PlayWalk(_userInput);
        }
    }

    private void FlipSprite()
    {
        if (_userInput.HorizontalInput < 0.0f)
            transform.localRotation = _rotateLeft;
        else if (_userInput.HorizontalInput > 0.0f)
            transform.localRotation = _rotateRight;
    }
}
