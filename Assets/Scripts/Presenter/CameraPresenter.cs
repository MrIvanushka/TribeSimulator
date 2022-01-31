using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TribeToSurvive.Model;

[RequireComponent(typeof(CameraInput))]
public class CameraPresenter : MonoBehaviour
{
    private CameraMovement _model;

    private void Awake()
    {
        _model = new CameraMovement(transform.position);
        GetComponent<CameraInput>().Initialize(_model);
    }

    private void OnEnable()
    {
        _model.Moved += Move;
    }

    private void OnDisable()
    {
        _model.Moved -= Move;
    }

    private void Update()
    {
        _model.Update(Time.deltaTime);
    }

    private void Move()
    {
        transform.position = _model.Position;
    }


}
