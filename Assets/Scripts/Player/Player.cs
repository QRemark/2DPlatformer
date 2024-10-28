using UnityEngine;

[RequireComponent(typeof(Animator), typeof(UserInput), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation), typeof(GroundDetector), typeof(Collector))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private GroundDetector _groundDetector;

    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

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
        FlipSprite();
        Play();
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

    private void Play()
    {
        if (_groundDetector.IsGround == false)
        {
            _playerAnimation.PlayFall();
            return;
        }

        if (_userInput.GetIsJump())
        {
            _playerMover.DirectY();
            _playerAnimation.PlayJump();
        }
        else if (_userInput.HorizontalInput == 0f)
        {
            _playerMover.StopMoving();
            _playerAnimation.PlayIdle();
        }
        else
        {
            _playerMover.SetDirection(_userInput.HorizontalInput);

            if (_userInput.ShiftInput)
            {
                _playerMover.DirectXFast();
                _playerAnimation.PlayRun(_userInput);
            }
            else
            {
                _playerMover.DirectX();
                _playerAnimation.PlayWalk(_userInput);
            }
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