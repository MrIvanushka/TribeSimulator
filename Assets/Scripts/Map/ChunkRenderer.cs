using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class ChunkRenderer : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Chunk _chunkTemplate;
    [SerializeField] private SelectedUnitsController _selectedUnitsController;

    private Chunk[,] _chunks;

    public void Initialize(ChunkData[,] data)
    {
        _chunks = new Chunk[data.GetLength(0), data.GetLength(1)];

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                _chunks[i, j] = Instantiate(_chunkTemplate, new Vector3(i * 10, 0, j * 10), Quaternion.identity);
                _chunks[i, j].Initialize(data[i, j], _selectedUnitsController);
            }
        }
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
