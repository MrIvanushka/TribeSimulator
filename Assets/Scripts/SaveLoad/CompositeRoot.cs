using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TribeToSurvive.SaveSystems;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PresenterFactory _factory;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private Transform _camera;

    private void Awake()
    {
        GameData data = SaveSystem.LoadGame();

        foreach(var sceneObject in data.Objects)
        {
            _factory.CreateTemplate(sceneObject);
        }
        _camera.position = new Vector3(data.CameraPosition.X, data.CameraPosition.Y, data.CameraPosition.Z);
        _navMeshSurface.BuildNavMesh();
    }
}
