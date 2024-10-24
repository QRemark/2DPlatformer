using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private float _animatorSpeedScaler = 2.0f;

    private string _animatorSpeed = "Speed";
    private string _animatorFall = "IsGrounded";
    private string _animatorJump = "JumpTrigger";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayFall() =>
        _animator.SetBool(_animatorFall, false);

    public void PlayJump()
    {
        _animator.SetBool(_animatorFall, true);
        _animator.SetTrigger(_animatorJump);
    }

    public void PlayIdle()
    {
        _animator.SetBool(_animatorFall, true);
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(0));
    }

    public void PlayWalk(UserInput userInput)
    {
        _animator.SetBool(_animatorFall, true);
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput));
    }

    public void PlayRun(UserInput userInput)
    {
        _animator.SetBool(_animatorFall, true);
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput) * _animatorSpeedScaler);
    }
}
