using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UserInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(GroundDetector))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private GroundDetector _groundDetector;

    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

    private int _coinsInPocket = 0;

    private void Awake()
    {
        GetComponents();
    }

    private void Update()
    {
        ReadInput();
        Live();
    }

    public void CollectCoin()
    {
        _coinsInPocket++;
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

    private void Live()
    {
        if ( _groundDetector.IsGround == false)
        {
            Fall();
            return;
        }

        if (_userInput.VerticalInput)
        {
            Jump();
        }
        else if(_userInput.HorizontalInput == 0f)
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
        FlipSprite(_userInput);
        _playerAnimation.PlayIdle();
    }

    private void Walk()
    {
        FlipSprite(_userInput);
        _playerMover.ChangePositionX(_userInput);
        _playerAnimation.PlayWalk(_userInput);
    }

    private void Run()
    {
        FlipSprite(_userInput);
        _playerMover.ChangePositionXSpeed(_userInput);
        _playerAnimation.PlayRun(_userInput);
    }

    private void Jump()
    {
        FlipSprite(_userInput);
        _playerMover.ChangePositionY(_userInput, _groundDetector.IsGround);
        _playerAnimation.PlayJump();
    }

    private void Fall()
    {
        FlipSprite(_userInput);
        _playerAnimation.PlayFall();
    }

    private void FlipSprite(UserInput userInput)
    {
        if (userInput.HorizontalInput < 0.0f)
            transform.localRotation = _rotateLeft;
        else if (userInput.HorizontalInput > 0.0f)
            transform.localRotation = _rotateRight;
    }
}
