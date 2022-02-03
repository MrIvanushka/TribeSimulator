using System;
using System.Collections.Generic;
using System.Linq;

namespace TribeToSurvive.Model
{
    public class SelectedSquad
    {
        private IEnumerable<Unit> _selectedUnits;

        public SelectedSquad(params Unit[] units)
        {
            if (units == null)
                throw new ArgumentNullException();

            _selectedUnits = units;
        }

        public void Move(UnityEngine.Vector3 destination)
        {
            foreach(var unit in _selectedUnits)
                unit.SetDestination(destination);
        }

        public void BreakTree(Tree tree)
        {
            Unit worker = _selectedUnits.First();
            var unitsWithAxe = _selectedUnits.Where(unit => unit.Equipment == Equipment.Axe);

            if (unitsWithAxe.Count() > 0)
                worker = unitsWithAxe.First();

            worker.GoToBreak(tree);
        }

        public void BreakRock(Rock rock)
        {
            foreach(var unit in _selectedUnits)
            {
                if(unit.Equipment == Equipment.Pickaxe)
                {
                    unit.GoToBreak(rock);
                    return;
                }
            }

            throw new NotSupportedException();
        }
    }
}
