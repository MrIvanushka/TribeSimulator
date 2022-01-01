using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public readonly float CurrentTime;
    public readonly float FlamesHP;
    public readonly SerializableVector2 CameraPosition;
    public ChunkData[,] Chunks;
    public List<UnitData> Tribe;

    public GameData(ChunkData[,] chunks, UnitData unit)
    {
        Chunks = chunks;
        FlamesHP = 100;
        CurrentTime = 0;
        Tribe = new List<UnitData>() { unit };
        CameraPosition = unit.Position;
    }

    public GameData(ChunkData[,] chunks, List<UnitData> tribe, float flamesHP, float currentTime)
    {
        Chunks = chunks;
        FlamesHP = flamesHP;
        CurrentTime = currentTime;
        Tribe = tribe;
    }
}

[System.Serializable]
public abstract class ObjectData
{
    public readonly SerializableVector2 Position;

    public ObjectData(InteractableObject interactableObject)
    {
        Position = new SerializableVector2(interactableObject.transform.position);
    }

    public ObjectData(float positionX, float positionY)
    {
        Position = new SerializableVector2(positionX, positionY);
    }
}

[System.Serializable]
public struct SerializableVector2
{
    public readonly float X;
    public readonly float Y;

    public SerializableVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public SerializableVector2(Vector3 vector)
    {
        X = vector.x;
        Y = vector.z;
    }
}