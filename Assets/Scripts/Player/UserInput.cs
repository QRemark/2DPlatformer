using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{
    public event Action OnJumpPressed;
    public event Action<float> OnMovePressed;
    public event Action<bool> OnRunPressed;

    private string _horizontalMoveButtons = "Horizontal";

    private KeyCode _shiftKey = KeyCode.LeftShift;
    private KeyCode _spaceKey = KeyCode.Space;

    public float HorizontalInput { get; private set; }

    public bool ShiftInput { get; private set; }

    public void ListenKey()
    {
        HorizontalInput = Input.GetAxis(_horizontalMoveButtons);
        OnMovePressed?.Invoke(HorizontalInput);

        if (Input.GetKeyDown(_spaceKey))
        {
            OnJumpPressed?.Invoke();
        }

        ShiftInput = Input.GetKey(_shiftKey);
        OnRunPressed?.Invoke(ShiftInput);
    }
}
