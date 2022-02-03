using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TouchHandler : MonoBehaviour
{
    private UnitsInput _inputSystem;

    public event UnityAction TouchIsStarted;
    public event UnityAction TouchIsEnded;
    public event UnityAction ScreenTap;

    public Vector2 TouchPosition => _inputSystem.Touch.TouchPosition.ReadValue<Vector2>();

    private void Awake()
    {
        _inputSystem = new UnitsInput();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
        _inputSystem.Touch.TouchPress.started += ctx => StartTouch(ctx);
        _inputSystem.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        _inputSystem.Touch.Tap.performed += ctx => OnTap(ctx);
    }

    private void OnDisable()
    {
        _inputSystem.Touch.TouchPress.started -= ctx => StartTouch(ctx);
        _inputSystem.Touch.TouchPress.canceled -= ctx => EndTouch(ctx);
        _inputSystem.Disable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        TouchIsStarted?.Invoke();
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        TouchIsEnded?.Invoke();
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        ScreenTap?.Invoke();
    }
}
