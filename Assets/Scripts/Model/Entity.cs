using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public abstract class Entity : ISceneObject
    {
        private Vector3 _position;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z); 
        public float Rotation { get; private set; }

        public event Action<UnityEngine.Vector3> GotDestination;
        public event Action Destroying;
        public event Action ArrivedAtDestination;

        public Entity(Vector3 position, float rotation)
        {
            _position = position;
            Rotation = rotation;
        }

        public void SetDestination(UnityEngine.Vector3 destination)
        {
            GotDestination?.Invoke(destination);
        }

        public void Arrive()
        {
            ArrivedAtDestination?.Invoke();
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
