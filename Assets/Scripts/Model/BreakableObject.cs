using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public abstract class BreakableObject : ISceneObject
    {
        private Vector3 _position;
        private bool _isBroken;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);
        public float Rotation { get; private set; }
        public abstract int BreakingTime { get; }
        public bool IsBroken => _isBroken;

        public event Action WasBroken;
        public event Action Destroying;


        public BreakableObject(Vector3 position)
        {
            _position = position;
            Rotation = 0;
        }

        public void Break()
        {
            WasBroken?.Invoke();
            OnBreak();
        }

        protected virtual void OnBreak() { }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
