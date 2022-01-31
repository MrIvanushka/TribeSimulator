using System;
using System.Collections.Generic;

namespace TribeToSurvive.Model
{
    [Serializable]
    public class Chunk : ISceneObject
    {
        private Vector3 _position;
        private List<ISceneObject> _objects;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);
        public float Rotation { get; private set; }
        public IReadOnlyList<ISceneObject> Objects => _objects;

        public Action Destroying;

        public Chunk(Vector3 position, List<ISceneObject> objects)
        {
            _position = position;
            _objects = objects;
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
