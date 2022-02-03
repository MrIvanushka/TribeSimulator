namespace TribeToSurvive.Model
{
    public class Selector
    {
        private SelectedSquad _squad;

        public void Select(ISceneObject sceneObject)
        {
            Select((dynamic)sceneObject);
        }

        public void GetTap(UnityEngine.Vector3 hitPoint)
        {
            if (_squad != null)
            {
                _squad.Move(hitPoint);
                Deselect();
            }
        }

        public void Deselect()
        {
            _squad = null;
        }

        private void Select(Unit unit)
        {
            Deselect();
            _squad = new SelectedSquad(unit);
        }

        private void Select(Beast beast)
        {
            beast.RunAway();
        }

        private void Select(Tree tree)
        {
            if (_squad != null)
            {
                _squad.BreakTree(tree);
                Deselect();
            }
        }

        private void Select(Rock rock)
        {
            if(_squad != null)
            {
                _squad.BreakRock(rock);
                Deselect();
            }
        }
    }
}
