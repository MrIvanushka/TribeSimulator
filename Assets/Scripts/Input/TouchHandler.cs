using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TouchHandler : MonoBehaviour
{
    private UnitsInput _inputSystem;

    public event UnityAction<TouchData> TouchIsStarted;
    public event UnityAction<TouchData> TouchIsEnded;
    public event UnityAction<TouchData> ScreenTap;

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
        TouchIsStarted?.Invoke(new TouchData(_inputSystem.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime));
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        TouchIsEnded?.Invoke(new TouchData(TouchPosition, (float)context.time));
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        ScreenTap?.Invoke(new TouchData(TouchPosition, (float)context.time));
    }
}

public struct TouchData 
{
    public readonly Vector2 Position;
    public readonly float Time;

    public TouchData(Vector2 position, float time)
    {
        Position = position;
        Time = time;
    }
}
