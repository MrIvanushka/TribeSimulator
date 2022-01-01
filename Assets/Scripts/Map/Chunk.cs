using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Tree _treeTemplate;
    [SerializeField] private GameObject _wallTemplate;

    public void Initialize(ChunkData data, SelectedUnitsController selectedUnitsController)
    {
        foreach(var objectData in data._mapObjects)
        {
            if (objectData is TreeData)
            {
                Tree newTree = Instantiate(_treeTemplate, transform);
                newTree.transform.localPosition = new Vector3(objectData.Position.X / 2 - 5, 0, objectData.Position.Y / 2 - 5);
                newTree.Initialize(selectedUnitsController);
            }
            else if (objectData is WallData)
            {
                GameObject wall = Instantiate(_wallTemplate, transform);
                wall.transform.localPosition = new Vector3(objectData.Position.X / 2 - 5, 0, objectData.Position.Y / 2 - 5);
            }
        }
    }
}
