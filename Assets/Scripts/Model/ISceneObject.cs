using System;

namespace TribeToSurvive.Model
{
    public interface ISceneObject
    {
        UnityEngine.Vector3 Position { get; }

        public event Action Destroying;

        void Destroy();
    }
}
