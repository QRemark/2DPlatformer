using UnityEngine;

[RequireComponent(typeof(Animator), typeof(UserInput), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation), typeof(GroundDetector), typeof(Collector))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private GroundDetector _groundDetector;

    private void Awake()
    {
        GetComponents();
    }

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        PlayMove();
        PlayAnimation();
    }

    private void GetComponents()
    {
        _userInput = GetComponent<UserInput>();
        _playerMover = GetComponent<PlayerMover>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void ReadInput()
    {
        _userInput.LisentKey();
    }

    private void PlayAnimation()
    {
        if (_groundDetector.IsGround == false)
        {
            Fall();
            return;
        }

        if (_userInput.VerticalInput)
        {
            Jump();
        }
        else if (_userInput.HorizontalInput == 0f)
        {
            Idle();
        }
        else
        {
            if (_userInput.ShiftInput)
            {
                Run();
            }
            else
            {
                Walk();
            }
        }
    }

    private void Idle()
    {
        _playerAnimation.PlayIdle();
    }

    private void Walk()
    {
        _playerAnimation.PlayWalk(_userInput);
    }

    private void Run()
    { 
        _playerAnimation.PlayRun(_userInput);
    }

    private void Jump()
    {
        _playerAnimation.PlayJump();
    }

    private void Fall()
    {
        _playerAnimation.PlayFall();
    }

    private void PlayMove()
    {
        if (_userInput.GetIsJump() && _groundDetector.IsGround)
        {
            _playerMover.ChangePositionY(_userInput, _groundDetector.IsGround);
        }
        else
        {
            if (_userInput.ShiftInput)
            {
                _playerMover.ChangePositionXSpeed(_userInput);
            }
            else
            {
                _playerMover.ChangePositionX(_userInput);
            }
        }

        _playerMover.FlipSprite(_userInput);
    }
}