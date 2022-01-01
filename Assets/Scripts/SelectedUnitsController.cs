using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsController : MonoBehaviour
{
    private const float _unitDistance = 1f;

    private List<Unit> _selectedUnits = new List<Unit>();

    public void AddSelectedUnit(Unit selectedUnit)
    {
        if (_selectedUnits.Contains(selectedUnit) == false)
            _selectedUnits.Add(selectedUnit);
        else
            DeselectUnits();
    }

    public void DeselectUnits()
    {
        _selectedUnits = new List<Unit>();
    }

    public void MoveSelectedUnits(Vector3 destination)
    {
        if (_selectedUnits.Count > 0)
        {
            _selectedUnits.ForEach(unit => unit.Move(destination));
            DeselectUnits();
        }
    }

    public void BreakTree(Tree target)
    {

    }
}
