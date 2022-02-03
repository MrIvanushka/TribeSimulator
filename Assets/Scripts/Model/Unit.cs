using System.Threading;
using System.Threading.Tasks;

namespace TribeToSurvive.Model
{
    [System.Serializable]
    public class Unit : Entity
    {
        private bool _isInTribe;
        private Equipment _equipment;
        private BreakableObject _target;

        public Equipment Equipment => _equipment;

        public Unit(Vector3 position, float rotation = 0) : base(position, rotation)
        {
            _isInTribe = false;
            _equipment = Equipment.None;
        }

        public void GoToBreak(BreakableObject breakableObject)
        {
            SetDestination(breakableObject.Position);
            ArrivedAtDestination += BreakObjectAsync;
            _target = breakableObject;
        }

        private async void BreakObjectAsync()
        {
            await Task.Run(() => BreakObject());
        }

        private void BreakObject()
        {
            ArrivedAtDestination -= BreakObject;
            Thread.Sleep(_target.BreakingTime);
            _target.Break();
            _target = null;
        }
    }
}
