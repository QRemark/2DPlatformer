using UnityEngine;

public class UserInput : MonoBehaviour
{
    private string _horizontalMoveButtons = "Horizontal";

    private KeyCode _shiftKey = KeyCode.LeftShift;

    private KeyCode _spaceKey = KeyCode.Space;

    public float HorizontalInput { get; private set; }

    public bool VerticalInput { get; private set; }

    public bool ShiftInput { get; private set; }

    public void LisentKey()
    {
        HorizontalInput = Input.GetAxis(_horizontalMoveButtons);

        VerticalInput = Input.GetKeyDown(_spaceKey);

        ShiftInput = Input.GetKey(_shiftKey);
    }
}
