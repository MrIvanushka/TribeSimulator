using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private float _sensitivity;

    private bool _isMoving = false;
    private Vector2 _previousTouchPosition;

    private void OnEnable()
    {
        _touchHandler.TouchIsStarted += OnStartTouch;
        _touchHandler.TouchIsEnded += OnEndTouch;
    }

    private void OnDisable()
    {
        _touchHandler.TouchIsStarted -= OnStartTouch;
        _touchHandler.TouchIsEnded -= OnEndTouch;
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (_previousTouchPosition == new Vector2(0, 0))
                _previousTouchPosition = _touchHandler.TouchPosition;

            Move(_touchHandler.TouchPosition - _previousTouchPosition);
            _previousTouchPosition = _touchHandler.TouchPosition;
        }
    }

    private void OnStartTouch(TouchData touchData)
    {
        _previousTouchPosition = _touchHandler.TouchPosition;
        _isMoving = true;
        
    }

    private void OnEndTouch(TouchData touchData)
    {
        _isMoving = false;
    }

    private void Move(Vector2 delta)
    {
        transform.position -= new Vector3(delta.x, 0, delta.y) * _sensitivity;
    }
}
