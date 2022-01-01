using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChunkData
{
    public List<ObjectData> _mapObjects;

    public ChunkData(Transform chunk)
    {
        foreach(Transform child in chunk)
        {
            if(child.TryGetComponent<ISaveable>(out ISaveable saveableObject))
                _mapObjects.Add(saveableObject.GetData());
        }
    }

    public ChunkData(List<ObjectData> mapObjects)
    {
        _mapObjects = mapObjects;
    }
}
