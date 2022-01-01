using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private SelectedUnitsController _selectedUnitsController;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                Interract(touch);
            else if (touch.phase == TouchPhase.Moved)
                _cameraMovement.Move(touch.deltaPosition);
        }
        else
        {
            ScaleScreen();
        }
    }

    private void Interract(Touch touch)
    {
        InteractableObject interactableObject = null;

        if (Physics.Raycast(_camera.ScreenPointToRay(touch.position), out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<InteractableObject>(out interactableObject))
                interactableObject.Interact();
        }
        if (interactableObject == null)
        {
            _selectedUnitsController.MoveSelectedUnits(hit.point);
        }
    }

    private void ScaleScreen()
    {

    }
}
