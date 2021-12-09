using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInspector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private SelectedUnitsController _selection;

    private Camera _camera;
    private Vector3 _startSelectionPoint;
    private Vector3 _endSelectionPoint;
    private bool _isHoldingMouseButton = false;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isHoldingMouseButton == false)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, _groundLayer);
            _startSelectionPoint = hit.point;
            _isHoldingMouseButton = true;
        }
        else if (Input.GetMouseButtonUp(0) && _isHoldingMouseButton == true)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, _groundLayer);
            _endSelectionPoint = hit.point;
            _isHoldingMouseButton = false;
        }
    }

}
