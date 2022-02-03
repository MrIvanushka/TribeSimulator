using UnityEngine;
using TribeToSurvive.Model;

public class TapSelectionInput : MonoBehaviour
{
    [SerializeField] private TouchHandler _touchHandler;
    
    private Camera _mainCamera;
    private Selector _model;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _model = new Selector();
    }

    private void OnEnable()
    {
        _touchHandler.ScreenTap += Tap;
    }

    private void OnDisable()
    {
        _touchHandler.ScreenTap -= Tap;
    }

    private void Tap()
    {
        if(Physics.Raycast(_mainCamera.ScreenPointToRay(_touchHandler.TouchPosition), out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent<Presenter>(out Presenter presenter))
            {
                if(presenter.enabled == true)
                {
                    Debug.Log("Tap to model");
                    _model.Select(presenter.Model);
                    return;
                }
            }
        }
        _model.GetTap(hit.point);
    }
}
