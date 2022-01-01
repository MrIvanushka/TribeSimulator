using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    [SerializeField] private ChunkRenderer _chunkRenderer;
    [SerializeField] private Tribe _tribe;
    [SerializeField] private Transform _camera;

    private void Awake()
    {
        GameData data = SaveSystem.LoadGame();

        _chunkRenderer.Initialize(data.Chunks);
        _tribe.Initialize(data.Tribe);
        _camera.position = new Vector3(data.CameraPosition.X, _camera.position.y, data.CameraPosition.Y);
    }
}
