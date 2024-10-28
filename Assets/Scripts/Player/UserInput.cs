using UnityEngine;

public class UserInput : MonoBehaviour
{
    private string _horizontalMoveButtons = "Horizontal";

    private bool _isJump;

    private KeyCode _shiftKey = KeyCode.LeftShift;

    private KeyCode _spaceKey = KeyCode.Space;

    public float HorizontalInput { get; private set; }

    public bool ShiftInput { get; private set; }

    public void LisentKey()
    {
        HorizontalInput = Input.GetAxis(_horizontalMoveButtons);

        if(Input.GetKeyDown(_spaceKey))
        {
            _isJump = true;
        }

        ShiftInput = Input.GetKey(_shiftKey);
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
