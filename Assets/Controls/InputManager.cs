using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    private bool interactPressed;
    private bool submitPressed;

    private static InputManager instance; // Singleton

    private void Awake()
    {
        instance = this;
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

}
