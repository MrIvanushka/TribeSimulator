using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public class Campfire : ISceneObject
    {
        private Vector3 _position;
        private float _fuel;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);
        public float Rotation { get; private set; }

        public event Action Destroying;
        public event Action GameOver;

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
