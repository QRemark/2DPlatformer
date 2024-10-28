using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private float _animatorSpeedScaler = 2.0f;
    private float _speed;

    private bool _isGrounded;

    //private string _animatorSpeed = "Speed";
    //private string _animatorFall = "IsGrounded";
    //private string _animatorJump = "JumpTrigger";

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
        //_animator.SetBool(_animatorFall, false);
    }

    public void PlayJump()
    {
        SetGrounded(true);
        _animator.SetTrigger(PlayerAnimatorData.Params.JumpTrigger);
        //_animator.SetBool(_animatorFall, true);
        //_animator.SetTrigger(_animatorJump);
    }

    public void PlayIdle()
    {
        SetGrounded(true);
        SetSpeed(0);
        //_animator.SetBool(_animatorFall, true);
        //_animator.SetFloat(_animatorSpeed, Mathf.Abs(0));
    }

    public void PlayWalk(UserInput userInput)
    {
        SetGrounded(true);
        SetSpeed(userInput.HorizontalInput);
        //_animator.SetBool(_animatorFall, true);
        //_animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput));
    }

    public void PlayRun(UserInput userInput)
    {
        SetGrounded(true);
        SetSpeed(userInput.HorizontalInput * _animatorSpeedScaler);
        //_animator.SetBool(_animatorFall, true);        
        //_animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput) * _animatorSpeedScaler);
    }
}
