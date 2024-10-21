using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    //private int _localScale = 5;

    private float _animatorSpeedScaler = 2.0f;

    private string _animatorSpeed = "Speed";
    private string _animatorFall = "IsGrounded";
    private string _animatorJump = "JumpTrigger";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //public void PlayJump(UserInput userInput)
    //{
    //    if (userInput.VerticalInput)
    //    {
    //        _animator.SetBool(_animatorJump, true);
    //    }
    //    else if (_animator.GetBool(_animatorJump))
    //    {
    //        _animator.SetBool(_animatorJump, false);
    //    }
    //}

    public void PlayFall()=>
        _animator.SetBool(_animatorFall, false);

    public void PlayJump()
    {
        _animator.SetBool(_animatorFall, true);
        _animator.SetTrigger(_animatorJump);
    }

    public void PlayIdle(UserInput userInput)
    //{
    //    if (userInput.HorizontalInput == 0.0f)
        {
        //        FlipSprite(userInput);
        _animator.SetBool(_animatorFall, true);
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(0));
        }
    //}

    public void PlayWalk(UserInput userInput) 
    //{
    //    if (userInput.HorizontalInput != 0.0f && userInput.ShiftInput == false)// перетащить эту логику в плеера все таки, переделать прыжок на триггер, булка на полет
        {
        //        FlipSprite(userInput);
        _animator.SetBool(_animatorFall, true);
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput));
        }
    //}

    public void PlayRun(UserInput userInput) 
    //{
    //    if (userInput.HorizontalInput != 0.0f && userInput.ShiftInput == true)
        {
    //        FlipSprite(userInput);
    _animator.SetBool(_animatorFall, true);
    _animator.SetFloat(_animatorSpeed, Mathf.Abs(userInput.HorizontalInput) * _animatorSpeedScaler);
        }
    //}

    //private void FlipSprite(UserInput userInput)//перебросить в плеера
    //{
    //    if (userInput.HorizontalInput < 0.0f)
    //        transform.localScale = new Vector3(-_localScale, _localScale, 1);
    //    else if (userInput.HorizontalInput > 0.0f)
    //        transform.localScale = new Vector3(_localScale, _localScale, 1);
    //}
}
