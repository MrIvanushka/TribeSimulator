using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TribeToSurvive.SaveSystems;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PresenterFactory _factory;
    [SerializeField] private Transform _camera;

    private void Awake()
    {
        GameData data = SaveSystem.LoadGame();

        foreach(var chunk in data.Chunks)
        {
            _factory.CreateTemplate(chunk);
        }
        _camera.position = new Vector3(data.CameraPosition.X, data.CameraPosition.Y, data.CameraPosition.Z);
    }
}
