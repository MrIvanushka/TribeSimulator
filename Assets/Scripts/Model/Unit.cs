namespace TribeToSurvive.Model
{
    [System.Serializable]
    public class Unit : Entity
    {
        private bool _isInTribe;
        private Equipment _equipment;

        public Unit(Vector3 position, float rotation = 0) : base(position, rotation)
        {
            _isInTribe = false;
            _equipment = Equipment.None;
        }
    }
}
