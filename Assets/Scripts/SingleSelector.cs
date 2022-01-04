using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelector : MonoBehaviour
{
    [SerializeField] private SelectedUnitsController _unitController;
    [SerializeField] private TouchHandler _touchHandler;

    private Camera _mainCamera;

    private void OnEnable()
    {
        _touchHandler.ScreenTap += OnScreenTap;
    }

    private void OnDisable()
    {
        _touchHandler.ScreenTap -= OnScreenTap;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void OnScreenTap(TouchData data)
    {
        if(Physics.Raycast(_mainCamera.ScreenPointToRay(data.Position), out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent(out InteractableObject interactable))
            {
                interactable.Interact();
            }
            else
            {
                _unitController.MoveSelectedUnits(hit.point);
            }
        }
    }
}
