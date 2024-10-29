using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{
    private const string _horizontalMoveButtons = "Horizontal";

    private KeyCode _shiftKey = KeyCode.LeftShift;
    private KeyCode _spaceKey = KeyCode.Space;

    public float HorizontalInput { get; private set; }

    public bool ShiftInput { get; private set; }

    public event Action Jumped;
    public event Action<float> Moved;
    public event Action<bool> Raced;

    public void ListenKey()
    {
        HorizontalInput = Input.GetAxis(_horizontalMoveButtons);
        Moved?.Invoke(HorizontalInput);

        if (Input.GetKeyDown(_spaceKey))
        {
            Jumped?.Invoke();
        }

        ShiftInput = Input.GetKey(_shiftKey);
        Raced?.Invoke(ShiftInput);
    }
}
