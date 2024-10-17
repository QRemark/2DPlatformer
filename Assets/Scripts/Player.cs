using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UserInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        GetComponents();
    }

    private void Update()
    {
        ReadInput();
        ChangePosition();
        PlayAnimation();
    }

    private void GetComponents()
    {
        _userInput = GetComponent<UserInput>();
        _playerMover = GetComponent<PlayerMover>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void ReadInput()
    {
        _userInput.LisentKey();
    }

    private void ChangePosition()
    {
        _playerMover.ChangePositionX(_userInput);
        _playerMover.ChangePositionY(_userInput);
    }

    private void PlayAnimation()
    {
        _playerAnimation.PlayJump(_userInput);
        _playerAnimation.PlayIdle(_userInput);
        _playerAnimation.PlayWalk(_userInput);
        _playerAnimation.PlayRun(_userInput);
    }
}
