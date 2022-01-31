using System;

namespace TribeToSurvive.Model
{
    public class CameraMovement : ISceneObject, IUpdatable
    {
        private Vector3 _position;
        private Vector3 _velocity;
        private const float _acceleration = 0.99f;
        private const float _sensitivity = 20f;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);

        public Action Destroying;
        public Action Moved;

        public CameraMovement(UnityEngine.Vector3 position)
        {
            _position = new Vector3(position);
            _velocity = new Vector3(0, 0, 0);
        }

        public void Update(float deltaTime)
        {
            
            _position += _velocity * -1 * _sensitivity * deltaTime;
            _velocity *= _acceleration;
            Moved?.Invoke();
        }

        public void Accelerate(UnityEngine.Vector2 delta)
        {
            if (delta.magnitude > 0.1f)
            {
                delta = delta.normalized;
                _velocity = new Vector3(delta.x, 0, delta.y);
            }
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}