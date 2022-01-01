using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    private SelectedUnitsController _unitController;

    public void Initialize(SelectedUnitsController unitController)
    {
        _unitController = unitController;
    }

    public override void Interact()
    {
        _unitController.BreakTree(this);
    }
}

[System.Serializable]
public class TreeData : ObjectData
{
    public readonly bool IsAlive;

    public TreeData(float positionX, float positionY) : base(positionX, positionY)
    {
        IsAlive = true;
    }
}
