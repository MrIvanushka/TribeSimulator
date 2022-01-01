using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : InteractableObject
{
    private NavMeshAgent _ai;
    private Equipment _equipment = Equipment.None;
    private bool _isInTribe;
    [SerializeField]private SelectedUnitsController _selectedUnitsController;

    public event UnityAction<Unit> IsDied;

    private void Start()
    {
        _ai = GetComponent<NavMeshAgent>();
    }

    public void Initialize(SelectedUnitsController selectedUnitsController, Equipment equipment, bool isInTribe)
    {
        _selectedUnitsController = selectedUnitsController;
        _equipment = equipment;
    }

    public override void Interact()
    {
        _selectedUnitsController.AddSelectedUnit(this);
    }

    public void Move(Vector3 destination)
    {
        _ai.SetDestination(destination);
    }

    public void Die()
    {
        IsDied.Invoke(this);
        IsDied = null;
        Destroy(this.gameObject);
    }
}

[System.Serializable]
public class UnitData : ObjectData
{
    public readonly Equipment SelfEquipment;
    public readonly bool IsInTribe;

    public UnitData(float positionX, float positionY, Equipment equipment = Equipment.None) : base(positionX, positionY)
    {
        SelfEquipment = equipment;
        IsInTribe = true;
    }

    public UnitData(Unit unit) : base(unit)
    {

    }
}

public enum Equipment
{
    None,
    Spear,
    Axe
}
