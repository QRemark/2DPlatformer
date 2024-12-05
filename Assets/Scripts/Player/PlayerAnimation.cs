using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private float _animatorSpeedScaler = 2.0f;
    private float _speed;

    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
    }

    private void SetSpeed(float speed)
    {
        _speed = Mathf.Abs(speed);
        _animator.SetFloat(PlayerAnimatorData.Params.Speed, _speed);
    }

    public void PlayFall()
    {
        SetGrounded(false);
    }

    public void PlayJump()
    {
        SetGrounded(true);
        _animator.SetTrigger(PlayerAnimatorData.Params.JumpTrigger);
    }

    public void PlayIdle()
    {
        SetGrounded(true);
        SetSpeed(0);
    }

    public void PlayWalk(UserInput userInput)
    {
        SetGrounded(true);
        SetSpeed(userInput.HorizontalInput);
    }

    public void PlayRun(UserInput userInput)
    {
        SetGrounded(true);
        SetSpeed(userInput.HorizontalInput * _animatorSpeedScaler);
    }

    public void PlayShoot()
    {
        SetGrounded(true);
        _animator.SetTrigger(PlayerAnimatorData.Params.ShootTrigger); //тут триггер что производим выстрел
    }
}
