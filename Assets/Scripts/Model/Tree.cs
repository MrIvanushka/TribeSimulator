using System;

namespace TribeToSurvive.Model
{
    [Serializable]
    public class Tree : ISceneObject
    {
        private Vector3 _position;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);
        public float Rotation { get; private set; }

        public Action Destroying;

        public Tree(Vector3 position)
        {
            _position = position;
            Rotation = 0;
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
