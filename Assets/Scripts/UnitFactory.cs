using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] private Unit _unitTemplate;
    [SerializeField] private SelectedUnitsController _selectedUnitsController;

    public Unit CreateUnit(UnitData data)
    {
        Vector3 unitPosition = new Vector3(data.Position.X, 0, data.Position.Y);
        Unit newUnit = Instantiate(_unitTemplate, unitPosition, Quaternion.identity);
        newUnit.Initialize(_selectedUnitsController, data.SelfEquipment, data.IsInTribe);
        return newUnit;
    }
}
