using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tribe : MonoBehaviour
{
    [SerializeField] private UnitFactory _unitFactory;
    
    private List<Unit> _members;
    
    public void Initialize(List<UnitData> unitDatas)
    {
        unitDatas.ForEach(data => _unitFactory.CreateUnit(data));
    }

    public void AddMember(Unit newMember)
    {
        newMember.IsDied += RemoveMember;
        _members.Add(newMember);
    }

    private void RemoveMember(Unit lostMember)
    {
        _members.Remove(lostMember);
    }
}
