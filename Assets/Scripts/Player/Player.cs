using UnityEngine;

[RequireComponent(typeof(UserInput), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation), typeof(GroundDetector), typeof(Collector))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerWeapon _weapon;

    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

    private bool _isRunning;
    private bool _isJumping;
    private bool _jumpRequest;
    private bool _isMoving;
    private bool _isShooting;
    private bool _isCooldown = false;

    private void Awake()
    {
        _userInput.Jumped += HandleJump;
        _userInput.Moved += HandleMove;
        _userInput.Raced += HandleRun;
        _userInput.Fired += HandleFire;
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
        if (_jumpRequest && _groundDetector.IsGround)
        {
            _playerMover.Jump(); 
            _jumpRequest = false; 
            _isJumping = true;
        }

        if (_isMoving)
            UpdateMoveHorizontal();
        else
            _playerMover.StopMoving();
    }

    private void UpdateMoveHorizontal()
    {
        if (_isRunning)
            _playerMover.MoveFast();
        else
            _playerMover.Move();
    }

    private void HandleFire()
    {
        if (_groundDetector.IsGround && _isJumping == false && _userInput.HorizontalInput == 0)
        {
            _isShooting=true;
            _weapon.TryShoot(out bool isCooldown);
            _isCooldown=isCooldown;
            Debug.Log("попытка Стрельба произведена в классе плеер!");
        }
        //else if(_isShooting == true)
        //    _isShooting = false;
        else
            _isShooting = false;
    }

    private void HandleJump()
    {
        if (_groundDetector.IsGround && _isJumping == false) 
        {
            _jumpRequest = true;
            _playerAnimation.PlayJump();
        }
    }

    private void HandleMove(float direction)
    {
        if (_userInput.HorizontalInput != 0)
        {
            _playerMover.SetDirection(direction);
            _isMoving = true;
        }
        else
            _isMoving = false;
    }

    private void HandleRun(bool isRunning)
    {
        _isRunning = isRunning;
    }

    private void UpdateAnimation()
    {
        if (_isShooting == true && _isCooldown == false)
        {
            UpdateShoot(); 
            return; 
        }

        if (_groundDetector.IsGround)
            UpdateAnimationHorizontal();
        else
        {
            if (_isJumping)
                return;

            _playerAnimation.PlayFall();
        }
    }

    private void UpdateShoot()
    {
        if (_userInput.HorizontalInput == 0)
        {
            _playerAnimation.PlayShoot(); 
            Debug.Log("Анимация стрелбы запущена в UpdateShoot!");
            _isShooting = false;
        }
        else
        {
            _isShooting = false;
        }
    }

    private void UpdateAnimationHorizontal()
    {
        _isJumping = false;

        //if (_userInput.HorizontalInput == 0 && _isShooting)///доделать перетащить фальс куда нибудь
        //{
        //    _playerAnimation.PlayShoot(); 
        //    Debug.Log("Анимация стрельбы запущена в плеер!");
        //    _isShooting = false; 
        //}
        if(_userInput.HorizontalInput == 0)
            _playerAnimation.PlayIdle();
        else if (_isRunning)
            _playerAnimation.PlayRun(_userInput);
        else
            _playerAnimation.PlayWalk(_userInput);
    }

    private void FlipSprite()
    {
        if (_userInput.HorizontalInput < 0.0f)
            transform.localRotation = _rotateLeft;
        else if (_userInput.HorizontalInput > 0.0f)
            transform.localRotation = _rotateRight;
    }
}
